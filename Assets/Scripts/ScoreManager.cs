using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int finalScore;
    public int maxScore = 999; 
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
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
    }

    public void ResetScore(int score)
    {
        finalScore += currentScore;
        currentScore = 0;
    }
}
