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
    public float height = 0;
    public Vector3 offset = new Vector3(3, 0, -20);
    public float smoothTime = 0.25f;
    private Vector3 currentVelocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 destination = target.position + offset;
        destination.y = height; // stops camera from moving on y axis
        transform.position = Vector3.SmoothDamp( 
             // updates camera so it follows player on x axis
            transform.position,
            destination,  // updates camera along x axis only
            ref currentVelocity,
            smoothTime
        );
        
    }
}
