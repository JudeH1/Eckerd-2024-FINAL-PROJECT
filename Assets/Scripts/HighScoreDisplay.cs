using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text HighScore;
    [SerializeField]private int scoreDisplay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay =  PlayerPrefs.GetInt("Highscore");
        Debug.Log(scoreDisplay);
        HighScore.text = scoreDisplay.ToString();
    }
}
