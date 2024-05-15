using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolBadGuy : MonoBehaviour
{
    public GameOver UIstuff;
    public GameObject player;

    public float viewRadius;

    public float viewAngle;

    public float moveSpeed = 1;

    public float rotateSpeed;

    public float rotationModifier;

    float directionX = 0;

    private float turning = 0;

    private float rotateCount = 0; 

    private float timer;

    bool currentlyColliding;

    private Quaternion targetRotation;
    public float angleOne;
    public float angleTwo;
    private Quaternion targetAngleOne = Quaternion.Euler(0, 0, 0);
    private Quaternion targetAngleTwo = Quaternion.Euler(0, 0, 0);

    public LayerMask Target;
    public LayerMask Wall;

    private Rigidbody2D rb2d;

    public Projectile bullet;
    private HealthManager health;
    public Transform bulletLaunchPos;

    public string difficulty;

    private enum State {
        Move,
        Turn,
        ChasePlayer,
        StopChasingPlayer
    }

    private State state;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = player.GetComponent<HealthManager>();
        targetAngleOne = Quaternion.Euler(0, 0, angleOne);
        targetAngleTwo = Quaternion.Euler(0, 0, angleTwo);
        targetRotation = transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        difficulty = "Medium";
        //difficulty = UIstuff.Whereever we store the difficulties
        state = State.Move;
    }


    void Update()
    {
        switch (state) {
           // default:
            case State.Move:
                if (LocatePlayer())
                {
                    state = State.ChasePlayer;
                }
                //step forward
                if (currentlyColliding)
                {
                    //Debug.Log("i want to die");
                    rotateCount = 0;
                    ChangeAngle();
                    state = State.Turn;
                }
                transform.position +=  transform.up * Time.deltaTime * moveSpeed;
                break;
            case State.Turn:  
                //while (rotateCount * Time.deltaTime < 180)
              //  {
                  //  rotateCount++;
                   // Debug.Log("hello");
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime);
               // }
                //float angle

               // if (rotateCount * Time.deltaTime >= 180)
               // {
               // state = State.Move; // once this is made smooth its important it stays in the turn state until it's finished turning
                //}
                transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, 0.5f);
                if (targetRotation.eulerAngles.z == transform.rotation.eulerAngles.z)
                {
                    state = State.Move;
                }
                break;
            case State.ChasePlayer:
                if (!LocatePlayer())
                {
                    state = State.StopChasingPlayer;
                }
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                Vector3 directionToPlayer = (player.transform.position - transform.position);
                float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                rb2d.rotation = angleToPlayer-90;
                if (difficulty == "Medium")
                {
                    Shoot();
                }
                break;

        

            case State.StopChasingPlayer:
                rb2d.velocity = new Vector2(0, 0);
                state = State.Move;
                break;

        }

    }

    void ChangeAngle()
    {
        if(targetRotation.eulerAngles.z==targetAngleOne.eulerAngles.z)
        {
            targetRotation = targetAngleTwo;
        }
        else
        {
            targetRotation = targetAngleOne;
        }
    }

    bool LocatePlayer()
    {
        Collider2D playerInRadius = Physics2D.OverlapCircle(transform.position, viewRadius, Target);

        if (playerInRadius != null)
        {
            Vector3 dirToPlayer = (playerInRadius.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.up, dirToPlayer) < viewAngle / 2)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, playerInRadius.transform.position);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dirToPlayer, distanceToPlayer, Wall);
                Debug.DrawLine(transform.position, playerInRadius.transform.position, Color.blue);
                if (!hit)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    // lots of redundant code below here but i want to make sure the state based stuff works before i delete
    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        Vector3 directionToPlayer = (player.transform.position - transform.position);
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        rb2d.rotation = angleToPlayer-90;
    }


    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision) // might need to change to be for walls only
    {
      if (collision.gameObject.CompareTag("Wall")){
        currentlyColliding = true;
      }
      if (collision.gameObject.CompareTag("Player"))
      {
        health.TakeDamage(1); //hopefully this doesnt repeat, might need to give player invulnerability period anyways
      }
    }

    void OnTriggerExit2D(Collider2D collision) // might need to change to be for walls only
    {
      if (collision.gameObject.CompareTag("Wall")){
        currentlyColliding = false;
      }
    }
    

    void Move(){
        //step forward
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }

    void Shoot()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            Instantiate(bullet, bulletLaunchPos.position, Quaternion.identity);
        }
    }


    //void Rotate()
   // {
    //    Vector3 eulerAngles = transform.rotation.eulerAngles;          
     //   transform.rotation = Quaternion.Euler(eulerAngles * -1);   
  //  }

}