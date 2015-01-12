using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour
{
    public float Speed = 20;

    Transform cachedTransform;

    void Start()
    {
        cachedTransform = this.transform;

         this.rigidbody.velocity = new Vector3(0, 0, -Speed);
    }

    void Update()
    {
        if (cachedTransform.position.z < -10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
