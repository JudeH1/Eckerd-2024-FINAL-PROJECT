using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public Transform castPoint;

    public float agroRange;

    public float moveSpeed;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (CanSeePlayer(agroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.right * distance;

        RaycastHit2D hit = Physics2D.Raycast(castPoint.position,transform.TransformDirection(Vector2.up), castDist);
        print(hit.collider != null);

        Debug.DrawRay(castPoint.position, transform.TransformDirection(Vector2.up), Color.black);
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
    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
