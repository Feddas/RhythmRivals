using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour
{
    public float Speed = 20;

    Vector3 cachedPosition;

    void Start()
    {
        cachedPosition = this.transform.position;
    }

    void Update()
    {
        if (this.transform.position.z > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - Speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 200);
        }
    }
}
