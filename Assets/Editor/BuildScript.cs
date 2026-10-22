using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Release builds of the enabled scenes in Build Settings, into Builds/ (git-ignored).
// Use the Build menu in the editor, or from the command line:
//   Unity.exe -batchmode -projectPath <project> -buildTarget Win64 -executeMethod BuildScript.BuildWindows
//   Unity.exe -batchmode -projectPath <project> -buildTarget WebGL -executeMethod BuildScript.BuildWebGL
public static class BuildScript
{
    [MenuItem("Build/Windows")]
    public static void BuildWindows()
    {
        Build(BuildTarget.StandaloneWindows64, "Builds/Windows/The Last Beat.exe");
    }

    [MenuItem("Build/WebGL")]
    public static void BuildWebGL()
    {
        Build(BuildTarget.WebGL, "Builds/WebGL");
    }

    private static void Build(BuildTarget target, string path)
    {
        string[] scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray();

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = path,
            target = target,
            targetGroup = BuildPipeline.GetBuildTargetGroup(target),
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;
        Debug.Log($"[BuildScript] {target}: {summary.result}, {summary.totalSize / (1024 * 1024)} MB, " +
                  $"{summary.totalErrors} errors, {summary.totalWarnings} warnings, {summary.totalTime:mm\\:ss}");

        // When run from the command line, exit with a code that says whether it worked
        if (Application.isBatchMode)
        {
            EditorApplication.Exit(summary.result == BuildResult.Succeeded ? 0 : 1);
        }
    }
}
