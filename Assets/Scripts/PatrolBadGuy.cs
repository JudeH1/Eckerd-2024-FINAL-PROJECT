using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolBadGuy : MonoBehaviour
{
    public Transform player;

    public float viewRadius;

    public float viewAngle;

    public float moveSpeed = 1;

    public float rotateSpeed;

    public float rotationModifier;

    float directionX = 0;

    private float turning = 0;

    private float rotateCount = 0; 

    bool currentlyColliding;

    private Quaternion targetRotation;

    public LayerMask Target;
    public LayerMask Wall;

    private Rigidbody2D rb2d;

    private enum State {
        Move,
        Turn,
        ChasePlayer,
        StopChasingPlayer,
    }

    private State state;

    void Start()
    {
        targetRotation = transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        state = State.Move;
    }


    void Update()
    {
        switch (state) {
           // default:
            case State.Move:
                if (locatePlayer())
                {
                    state = State.ChasePlayer;
                }
                //step forward
                if (currentlyColliding)
                {
                    rotateCount = 0;
                    state = State.Turn;
                }
                transform.position +=  transform.up * Time.deltaTime * moveSpeed;
                break;
            case State.Turn:  
                while (rotateCount * Time.deltaTime < 180)
                {
                    rotateCount++;
                    transform.Rotate (new Vector3 (0, 0, Time.deltaTime)); // ideally this should be a smooth rotation but for the life of me i cant get that
                }

                if (rotateCount * Time.deltaTime >= 180)
                {
                state = State.Move; // once this is made smooth its important it stays in the turn state until it's finished turning
                }
                break;
            case State.ChasePlayer:
                if (!(locatePlayer()))
                {
                    state = State.StopChasingPlayer;
                }
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
                Vector3 directionToPlayer = (player.position - transform.position);
                float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                rb2d.rotation = angleToPlayer-90;
                break;
            case State.StopChasingPlayer:
                rb2d.velocity = new Vector2(0, 0);
                state = State.Move;
                break;

        }

    }

    bool locatePlayer()
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        Vector3 directionToPlayer = (player.position - transform.position);
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        rb2d.rotation = angleToPlayer-90;
    }


    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision) // might need to change to be for walls only
    {
      currentlyColliding = true;
    }

    void OnTriggerExit2D(Collider2D collision) // might need to change to be for walls only
    {
      currentlyColliding = false;
    }
    

    void Move(){
        //step forward
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }

    //void Rotate()
   // {
    //    Vector3 eulerAngles = transform.rotation.eulerAngles;          
     //   transform.rotation = Quaternion.Euler(eulerAngles * -1);   
  //  }

}