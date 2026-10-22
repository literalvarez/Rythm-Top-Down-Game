using UnityEngine;

// Player setting for audio delay (e.g. Bluetooth headphones play sound late).
// BeatManager fires every beat event this much later, so input windows and
// beat-driven enemies line up with when the player actually hears the beat.
public static class AudioOffset
{
    public const string PrefsKey = "AudioOffsetMs";
    public const int MaxMilliseconds = 300;

    private static int? cachedMilliseconds;

    public static int Milliseconds
    {
        get
        {
            if (cachedMilliseconds == null)
            {
                cachedMilliseconds = Mathf.Clamp(PlayerPrefs.GetInt(PrefsKey, 0), 0, MaxMilliseconds);
            }
            return cachedMilliseconds.Value;
        }
    }

    public static float Seconds => Milliseconds / 1000f;

    public static void Set(int milliseconds)
    {
        cachedMilliseconds = Mathf.Clamp(milliseconds, 0, MaxMilliseconds);
        // Save right away: WebGL builds never call OnApplicationQuit
        PlayerPrefs.SetInt(PrefsKey, cachedMilliseconds.Value);
        PlayerPrefs.Save();
    }
}
