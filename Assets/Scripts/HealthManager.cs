using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 6;

    public float currentHealth;
    private ScoreManager score;
    private GameObject player;
    private HealthManager health;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        score = player.GetComponent<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        score.ResetScore(0); // loses streak
    }

    public void Heal(int healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Heal(1);
        }
    }
}
