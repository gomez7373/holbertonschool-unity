using UnityEngine;

/// <summary>
/// Forces landscape orientation when running on a mobile platform.
/// This is required because Android builds are generated via CLI (batchmode),
/// and Player Settings may not be manually adjusted before build.
/// </summary>
public class ForceLandscapeMobile : MonoBehaviour
{
    void Awake()
    {
        if (!Application.isMobilePlatform)
            return;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
}
