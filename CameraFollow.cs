using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform target;
    public Vector3 offset = new Vector3(3, 0, -20);
    public float smoothTime = 0.25f;

    Vector3 currentVelocity;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref currentVelocity,
            smoothTime
        );
        
    }
}
