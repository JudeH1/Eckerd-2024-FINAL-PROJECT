using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D rb;
    private HealthManager health;
    public float Speed = 4.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<HealthManager>();

        Vector3 dirToPlayer = player.transform.position - transform.position;
        rb.velocity = new Vector2 (dirToPlayer.x, dirToPlayer.y).normalized * Speed;

        float rotation = Mathf.Atan2(-dirToPlayer.y, -dirToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }   
     void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(1);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
