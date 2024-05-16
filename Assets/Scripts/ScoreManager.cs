using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int finalScore;
    public int maxScore = 999; 
    public int Easyhighscore = 0;
    public int Mediumhighscore = 0;
    public int Hardhighscore = 0;
    private HealthManager health;
    private GameObject player;

    private int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        Easyhighscore = PlayerPrefs.GetInt("EasyHighscore");
        Mediumhighscore = PlayerPrefs.GetInt("MediumHighscore");
        Hardhighscore = PlayerPrefs.GetInt("HardHighscore");
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
        difficulty = PlayerPrefs.GetInt("Difficulty");
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
        if (difficulty == 1)
        {
            if (finalScore > Easyhighscore)
            {
                Debug.Log(finalScore);
                Easyhighscore = finalScore;
                PlayerPrefs.SetInt ("EasyHighscore", Easyhighscore);
            }
        }
        if (difficulty == 2)
        {
            if (finalScore > Mediumhighscore)
            {
                Debug.Log(finalScore);
                Mediumhighscore = finalScore;
                PlayerPrefs.SetInt ("MediumHighscore", Mediumhighscore);
            }
        }
        if (difficulty == 3)
        {
            if (finalScore > Hardhighscore)
            {
                Debug.Log(finalScore);
                Hardhighscore = finalScore;
                PlayerPrefs.SetInt ("HardHighscore", Hardhighscore);
            }
        }
    }
}
