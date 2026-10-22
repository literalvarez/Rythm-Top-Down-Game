using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.Events;

// Online leaderboard using Unity Gaming Services (UGS) Leaderboards.
// UGS keeps one entry per signed-in player, so each typed name gets its own anonymous
// sign-in profile on this device: several people can play on one computer and each
// name keeps its own best score. The typed name is stored in the entry's metadata.
public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;
    public UnityEvent DoUpload;
    public UnityEvent DoFailedUpload;

    [SerializeField] private string leaderboardId = "Beat_Cube"; // Leaderboard ID from the Unity Cloud Dashboard

    private const int MaxProfileNameLength = 20; // UGS profiles allow 30 chars; leaves room for the hash suffix

    private static Task initializeTask;
    private static readonly SemaphoreSlim authLock = new SemaphoreSlim(1, 1); // One sign-in/profile switch at a time
    private bool isSubmitting;

    [Serializable]
    private class EntryMetadata
    {
        public string name;
    }

    public async void GetLeaderboard()
    {
        try
        {
            await EnsureSignedInAsync(null);
            LeaderboardScoresPage page = await LeaderboardsService.Instance.GetScoresAsync(
                leaderboardId, new GetScoresOptions { Limit = names.Count, IncludeMetadata = true });

            // The end screen may have been closed (scene restart) while we waited
            if (this == null) return;
            ShowEntries(page.Results);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Could not load leaderboard: " + e.Message);
        }
    }

    public async void SetLeaderboardEntry(string username, int score)
    {
        // Ignore double clicks while an upload is in progress
        if (isSubmitting) return;
        isSubmitting = true;

        try
        {
            await EnsureSignedInAsync(ProfileForName(username));
            await LeaderboardsService.Instance.AddPlayerScoreAsync(
                leaderboardId, score,
                new AddPlayerScoreOptions { Metadata = new Dictionary<string, string> { { "name", username } } });

            if (this == null) return;
            GetLeaderboard();
            DoUpload.Invoke();
        }
        catch (Exception e)
        {
            Debug.LogWarning("Could not upload score: " + e.Message);
            if (this != null)
            {
                DoFailedUpload.Invoke();
            }
        }
        finally
        {
            isSubmitting = false;
        }
    }

    private void ShowEntries(List<LeaderboardEntry> results)
    {
        int slots = Mathf.Min(names.Count, scores.Count);
        for (int i = 0; i < slots; i++)
        {
            bool hasEntry = i < results.Count;
            names[i].text = hasEntry ? DisplayName(results[i]) : "";
            scores[i].text = hasEntry ? ((long)results[i].Score).ToString() : "";
        }
    }

    // The name as the player typed it, or the UGS player name without its "#1234" suffix
    private static string DisplayName(LeaderboardEntry entry)
    {
        if (!string.IsNullOrEmpty(entry.Metadata))
        {
            EntryMetadata metadata = JsonUtility.FromJson<EntryMetadata>(entry.Metadata);
            if (metadata != null && !string.IsNullOrEmpty(metadata.name))
            {
                return metadata.name;
            }
        }

        string playerName = entry.PlayerName ?? "";
        int hashIndex = playerName.LastIndexOf('#');
        return hashIndex > 0 ? playerName.Substring(0, hashIndex) : playerName;
    }

    // Initializes UGS once and signs in. A non-null profile switches to that player's profile first.
    private static async Task EnsureSignedInAsync(string profile)
    {
        await authLock.WaitAsync();
        try
        {
            if (UnityServices.State != ServicesInitializationState.Initialized)
            {
                if (initializeTask == null || initializeTask.IsFaulted)
                {
                    initializeTask = UnityServices.InitializeAsync();
                }
                await initializeTask;
            }

            IAuthenticationService auth = AuthenticationService.Instance;
            if (profile != null && auth.Profile != profile)
            {
                if (auth.IsSignedIn)
                {
                    auth.SignOut(); // Keeps the saved session, so signing back into a profile restores the same player
                }
                auth.SwitchProfile(profile);
            }

            if (!auth.IsSignedIn)
            {
                await auth.SignInAnonymouslyAsync();
            }
        }
        finally
        {
            authLock.Release();
        }
    }

    // Turns a typed name into a valid UGS profile name ([a-zA-Z0-9_-], max 30 chars).
    // Case and spacing are ignored, and a hash keeps names like "José" and "Jose" apart.
    private static string ProfileForName(string username)
    {
        string key = username.Trim().ToLowerInvariant();

        StringBuilder safe = new StringBuilder();
        foreach (char c in key)
        {
            if (safe.Length >= MaxProfileNameLength) break;
            if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_' || c == '-')
            {
                safe.Append(c);
            }
        }

        // FNV-1a hash: stable across runs and platforms, unlike string.GetHashCode
        uint hash = 2166136261;
        foreach (char c in key)
        {
            hash = (hash ^ c) * 16777619;
        }

        string prefix = safe.Length > 0 ? safe.ToString() : "p";
        return prefix + "_" + hash.ToString("x8");
    }
}
