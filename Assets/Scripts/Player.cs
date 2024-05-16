using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{

private bool isFacingRight;
private float horizontalInput;
private HealthManager health;
private float verticalInput;
public float speed = 10.0f;
public int difficulty;
private Rigidbody2D rb;
// below is a diagram for direction
// ACTUALLY NEVER MIND LETS NOT USE THAT
// 1 2 3
// 4 0 5
// 6 7 8

void Start ()
{
   isFacingRight = true;
   rb = GetComponent<Rigidbody2D>();
   gameObject.tag = "Player";
   health = GetComponent<HealthManager>();
   //difficulty = PlayerPrefs.GetInt("Difficulty");
}

void OnCollisionEnter2D(Collision2D other)
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
       if (other.gameObject.CompareTag("Wall"))
        {
            if (health.currentHealth <= 0){
                DieDIEDIE();
            }
            if (difficulty == 3){
                health.TakeDamage(1); // walls hurt now
            }
            Debug.Log(difficulty);
        }
    }


void Update()
{
    horizontalInput = Input.GetAxis("Horizontal");
    verticalInput = Input.GetAxis("Vertical");
   // Debug.Log(horizontalInput);
    if (!isFacingRight && horizontalInput > 0)
    {
        Flip();
    }
    else if (isFacingRight && horizontalInput < 0)
    {
        Flip();
    }
    difficulty = PlayerPrefs.GetInt("Difficulty");
}


void LateUpdate(){
        rb.AddForce(new Vector3(horizontalInput, verticalInput, 0.0f) * speed);
    }

public void Flip()
{
    isFacingRight = !isFacingRight;
    Vector3 localScale = transform.localScale;
    localScale.x *= -1f;
    transform.localScale = localScale;

}
void DieDIEDIE(){
    speed = 0.0f;
}

}



