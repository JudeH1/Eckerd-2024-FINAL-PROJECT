using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

private float horizontalInput;
private float verticalInput;
public float speed = 10.0f;
private Rigidbody2D rb;
// below is a diagram for direction
// ACTUALLY NEVER MIND LETS NOT USE THAT
// 1 2 3
// 4 0 5
// 6 7 8

void Start ()
{
   rb = GetComponent<Rigidbody2D>();
}

void Update()
{
   horizontalInput = Input.GetAxis("Horizontal");
   verticalInput = Input.GetAxis("Vertical");

   
}


void LateUpdate(){
        rb.AddForce(new Vector3(horizontalInput, verticalInput, 0.0f) * speed);
    }
}



