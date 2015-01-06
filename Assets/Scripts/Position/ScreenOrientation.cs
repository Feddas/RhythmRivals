using UnityEngine;
using System.Collections;

public class ScreenOrientation : MonoBehaviour
{
    // track device moved from portrait to landscape event.
    static bool RotationLocked;
    static int LastWidth;

    void Start()
    {
        Application.targetFrameRate = 15;
    }

    void Update()
    {
        // raise device moved from portrait to landscape event.
        if (RotationLocked == false && Screen.width != LastWidth)
        {
            LastWidth = Screen.width;
            Globals.RaiseOrientationChangeEvent();
            Debug.Log("asdflocked to " + Screen.orientation.ToString());
        }
    }

    public void OnToggleOrientation(bool isOrientationLocked)
    {
        RotationLocked = isOrientationLocked;

        if (isOrientationLocked)
        {
            Screen.orientation = currentOrientation();
        }
        else
        {
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
        }

        Debug.Log("RotationLocked to " + RotationLocked);
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
