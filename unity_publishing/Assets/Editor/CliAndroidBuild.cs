using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_ANDROID
using UnityEditor.Android;
#endif

public static class CliAndroidBuild
{
    public static void Build()
    {
        string sdk = @"C:\Android\SDK";

#if UNITY_ANDROID
        try
        {
            AndroidExternalToolsSettings.sdkRootPath = sdk;
        }
        catch
        {
            EditorPrefs.SetString("AndroidSdkRoot", sdk);
        }
#else
        EditorPrefs.SetString("AndroidSdkRoot", sdk);
#endif

        string outDir = "Builds/Android";
        if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

        EditorUserBuildSettings.SwitchActiveBuildTarget(
            BuildTargetGroup.Android,
            BuildTarget.Android
        );

        EditorUserBuildSettings.buildAppBundle = false;

        var scenes = Directory.GetFiles("Assets", "*.unity", SearchOption.AllDirectories)
            .OrderBy(p => p)
            .ToArray();

        if (scenes.Length == 0)
        {
            Debug.LogError("No scenes found in Assets.");
            EditorApplication.Exit(2);
            return;
        }

        EditorBuildSettings.scenes = scenes
            .Select(p => new EditorBuildSettingsScene(p.Replace("\\", "/"), true))
            .ToArray();

        string apkPath = Path.Combine(outDir, "unity_publishing.apk");

        var opts = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray(),
            locationPathName = apkPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(opts);

        if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.LogError("Android build failed: " + report.summary.result);
            EditorApplication.Exit(1);
            return;
        }

        Debug.Log("Android APK built at: " + apkPath);
        EditorApplication.Exit(0);
    }
}
