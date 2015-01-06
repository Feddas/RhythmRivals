using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Globals : MonoBehaviour
{
    public Camera MainCamera;
    public delegate void OrientationChange();
    public static event OrientationChange OnOrientationChange;
    
    public static Globals Instance
    {
        get
        {
            return instance;
        }
        set { instance = value; }
    }
    private static Globals instance;
    
    public static void RaiseOrientationChangeEvent()
    {
        if (OnOrientationChange != null)
            OnOrientationChange();
    }

    void Awake()
    {
        if (instance == null)
            Instance = this;
        Debug.Log("awake " + Instance.ToString());
    }

    void Update()
    {
    }
}
