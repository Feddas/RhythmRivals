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
#if !UNITY_EDITOR
        position();
#endif
    }

    void Update()
    {
#if UNITY_EDITOR // provide live updating to the object
        position();
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
           // Debug.Log(PercentX + "+" + PercentY + " used to set to (" + newPos.x + ", " + newPos.y + ", " + newPos.z);
        }
        else
        {
            Debug.Log("couldn't postion " + this.name);
        }
    }
}
