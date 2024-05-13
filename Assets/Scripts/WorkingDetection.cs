using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

class WorkingDetection : MonoBehaviour
{
    public Transform player;

    public float viewRadius;
    public float viewAngle;
    public float moveSpeed;
    public float rotateSpeed;
    public float rotationModifier;
    private float timer;

    public LayerMask Target;
    public LayerMask Wall;

    private Rigidbody2D rb2d;

    public Projectile bullet;
    public Transform bulletLaunchPos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (LocatePlayer())
        {
            ChasePlayer();
            Shoot();
        }
        else
        {
            StopChasingPlayer();
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

    
    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        Vector3 directionToPlayer = (player.position - transform.position);
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        rb2d.rotation = angleToPlayer-90;
        Debug.Log(rb2d.rotation);
    }


    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
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
}