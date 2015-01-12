using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour
{
    public float Speed = 20;

    Transform cachedTransform;
    Vector3 cachedPosition;

    void Start()
    {
        cachedTransform = this.transform;

         this.rigidbody.velocity = new Vector3(0, 0, -Speed);
    }

    void Update()
    {
        cachedPosition = cachedTransform.position;
        if (cachedPosition.z > -10)
        {
            // commented out section is alternative to setting this.rigidbody.velocity
            //cachedPosition = new Vector3(cachedPosition.x, cachedPosition.y, cachedPosition.z - Speed * Time.deltaTime);
        }
        else
        {
            cachedPosition = new Vector3(cachedPosition.x, cachedPosition.y, 200);
        }
        cachedTransform.position = cachedPosition;
    }
}
