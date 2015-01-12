using UnityEngine;
using System.Collections;

public class ScreenOrientation : MonoBehaviour
{
    // track device moved from portrait to landscape event.
    static bool RotationLocked;
    static float LastAspect;

    void Start()
    {
        Application.targetFrameRate = 15;
    }

    void Update()
    {
        // raise device moved from portrait to landscape event.
        if (RotationLocked == false && Globals.Instance.MainCamera.aspect != LastAspect) // Note :MainCamera changes after Screen.width value
        {
            LastAspect = Globals.Instance.MainCamera.aspect;
            Globals.RaiseOrientationChangeEvent();
            //Debug.Log("orientation to " + Screen.orientation.ToString() + " aspect " + Globals.Instance.MainCamera.aspect);
        }
    }

    public void OnToggleOrientation(bool isOrientationLocked)
    {
        RotationLocked = isOrientationLocked;

        // this should be all that's needed to toggle orientation lock
        if (isOrientationLocked)
        {
            Screen.orientation = currentOrientation();
        }
        else
        {
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
        }

        // but adding this fixes some Nexus 5 orientation issues.
        Screen.autorotateToLandscapeLeft =
        Screen.autorotateToLandscapeRight =
        Screen.autorotateToPortrait =
        Screen.autorotateToPortraitUpsideDown = isOrientationLocked == false;

        //Debug.Log("RotationLocked " + RotationLocked + " to " + Screen.orientation);
    }

    UnityEngine.ScreenOrientation currentOrientation()
    {
        switch (Input.deviceOrientation)
        {
            case DeviceOrientation.LandscapeLeft:
                return UnityEngine.ScreenOrientation.LandscapeLeft;
            case DeviceOrientation.LandscapeRight:
                return UnityEngine.ScreenOrientation.LandscapeRight;
            case DeviceOrientation.PortraitUpsideDown:
                return UnityEngine.ScreenOrientation.PortraitUpsideDown;
            case DeviceOrientation.Portrait:
            case DeviceOrientation.Unknown:
            case DeviceOrientation.FaceDown:
            case DeviceOrientation.FaceUp:
            default:
                return UnityEngine.ScreenOrientation.Portrait;
        }
    }
}
