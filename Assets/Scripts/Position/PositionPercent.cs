using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PositionPercent : MonoBehaviour
{
    public float PercentX, PercentY;

    void OnEnable()
    {
        Globals.OnOrientationChange += position;
    }

    void OnDisable()
    {
        Globals.OnOrientationChange -= position;
    }

    void Start()
    {
    }

    void Update()
    {
#if UNITY_EDITOR // provide live updating to the object
       // position();
#endif
    }

    void position()
    {
        if (Globals.Instance && Globals.Instance.MainCamera)
        {
            var newPos =
                Globals.Instance.MainCamera.ScreenToWorldPoint(new Vector3(
                    Screen.width * PercentX,
                    Screen.height * PercentY,
                    10f));

            newPos.z = this.transform.position.z;

            this.transform.position = newPos;

            //debug
            string current = " Size (" + Screen.width + ", " + Screen.height + ") " + PercentX + "+" + PercentY,
                applied = " used to set to (" + newPos.x + ", " + newPos.y + ", " + newPos.z;
            //Debug.Log(current + applied);

            Globals.Instance.DebugText.text = "Positioned for aspect " + Globals.Instance.MainCamera.aspect + current + applied;
        }
        else
        {
            Debug.Log("couldn't postion " + this.name);
        }
    }
}
