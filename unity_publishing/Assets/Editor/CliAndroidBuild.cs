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
        // Android SDK path (copied out of Program Files to avoid read-only issues)
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

        // ------------------------------------------------------------
        // ORIGINAL output directory (kept for reference)
        // string outDir = "Builds/Android";
        //
        // NEW output directory:
        // We store Android builds in Builds/movil
        // to avoid overwriting previous Android builds.
        // ------------------------------------------------------------
        string outDir = "Builds/movil";

        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);

        // Ensure Android is the active build target
        EditorUserBuildSettings.SwitchActiveBuildTarget(
            BuildTargetGroup.Android,
            BuildTarget.Android
        );

        // Build APK (not App Bundle)
        EditorUserBuildSettings.buildAppBundle = false;

        // Collect all .unity scenes under Assets
        var scenes = Directory.GetFiles("Assets", "*.unity", SearchOption.AllDirectories)
            .OrderBy(p => p)
            .ToArray();

        if (scenes.Length == 0)
        {
            Debug.LogError("No scenes found in Assets.");
            EditorApplication.Exit(2);
            return;
        }

        // Register scenes for the build
        EditorBuildSettings.scenes = scenes
            .Select(p => new EditorBuildSettingsScene(p.Replace("\\", "/"), true))
            .ToArray();

        // ------------------------------------------------------------
        // ORIGINAL APK path (kept commented for memory)
        // string apkPath = Path.Combine("Builds/Android", "unity_publishing.apk");
        //
        // ACTIVE APK path (Builds/movil)
        // ------------------------------------------------------------
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
