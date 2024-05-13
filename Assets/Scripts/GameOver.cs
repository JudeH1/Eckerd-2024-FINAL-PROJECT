using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    private HealthManager health;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject restartText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject highScoreTitle;
    [SerializeField] private GameObject highScoreDisplay;
    [SerializeField] private GameObject mainMenuText;
    [SerializeField] private GameObject mainMenuButton;
    private GameObject player;
    //[SerializeField] private Text restartText;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
      //  restartText.gameObject.SetActive(false); all commented out from when i was gonna make it turn on one by one
        //restartButton.gameObject.SetActive(false);
        //highScoreTitle.gameObject.SetActive(false);
        //highScoreDisplay.gameObject.SetActive(false);
        //mainMenuText.gameObject.SetActive(false);
        //mainMenuButton.gameObject.SetActive(false);
        player =  GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health.currentHealth <= 0 && !isGameOver)// remove debug at some point
        {
            isGameOver = true;
            
            StartCoroutine(GameOverSequence());
        }
    }


    private IEnumerator GameOverSequence()
    {
        gameOverText.SetActive(true);
        
        yield return new WaitForSeconds(5.0f);
       // gameOverText.SetActive(false);
        //restartText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
       // highScoreTitle.gameObject.SetActive(true);
        //highScoreDisplay.gameObject.SetActive(true);
        //mainMenuText.gameObject.SetActive(true);
        //mainMenuButton.gameObject.SetActive(true);


    }

    public void startGame(){
        SceneManager.LoadScene("Game");
    }

    public void mainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    
    
}
