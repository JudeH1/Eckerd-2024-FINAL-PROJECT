using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerMoverment : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 5f;
    Vector2 movement;
    // Update is called once per frame
    void Update(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate (){
        //move character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
