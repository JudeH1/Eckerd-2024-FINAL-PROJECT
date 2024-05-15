using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int finalScore;
    public int maxScore = 999; 
    public int highscore = 0;
    private HealthManager health;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        player = GameObject.FindGameObjectWithTag("Player");
        currentScore = 0;
        health = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore > 998)
        {
            currentScore = 999;
        }

    }
    
    public void UpdateScore(int score)
    {
        currentScore += score;
        if (currentScore % 200 == 0){ // gives health for every 200 points gained without losing hp
        if (health.currentHealth < health.maxHealth){
        health.Heal(1);
        }
        else{
            //health.maxHealth += 1; // increases maxhealth if hp full (actually i changed my mind this makes the game too grindy i dont like it)
            // maybe give the player a powerup in this case?
            health.Heal(1);
        }
        }
    }

    public void ResetScore(int score)
    {
        finalScore += currentScore;
        currentScore = 0;
        if (finalScore > highscore){
        Debug.Log(finalScore);
        highscore = finalScore;
        PlayerPrefs.SetInt ("Highscore", highscore);
    }
}
}
