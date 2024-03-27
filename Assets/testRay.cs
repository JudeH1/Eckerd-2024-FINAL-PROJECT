using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class testRay : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    public Transform castPoint;

    private bool val;

    private bool test;
    void Start()
    {
        test = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (CanSeePlayer())
        {
            test = true;
        }
        else
        {
            test= false;
        }
        bool CanSeePlayer()
        {
            RaycastHit2D hit = Physics2D.Raycast(castPoint.position, transform.TransformDirection(Vector2.up));
            Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.black);
            Debug.Log(hit.point);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    val = true;
                }
                else
                {
                    val = false;
                }
            }
            return val;

        }
    }
}
