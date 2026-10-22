using UnityEngine;
using UnityEngine.SceneManagement;

// Tracks when the scene is being closed (scene change, restart or quit),
// so OnDestroy logic doesn't spawn objects or trigger gameplay events during teardown.
public static class SceneTeardown
{
    public static bool IsTearingDown { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Init()
    {
        IsTearingDown = false;
        Application.quitting -= OnQuitting;
        Application.quitting += OnQuitting;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Use this instead of SceneManager.LoadScene so OnDestroy scripts know the scene is closing
    public static void LoadScene(int buildIndex)
    {
        IsTearingDown = true;
        SceneManager.LoadScene(buildIndex);
    }

    public static void LoadScene(string sceneName)
    {
        IsTearingDown = true;
        SceneManager.LoadScene(sceneName);
    }

    private static void OnQuitting()
    {
        IsTearingDown = true;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        IsTearingDown = false;
    }
}
