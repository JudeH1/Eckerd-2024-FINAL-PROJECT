using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    private ScoreManager score;
    private HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<ScoreManager>();
        health = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (health.currentHealth > 0){
            score.UpdateScore(1);
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            //don't increase score
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("WallOfDeath"))
        {
            //don't increase score
            Destroy(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }
}
