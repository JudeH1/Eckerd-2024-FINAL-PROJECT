using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    private HealthManager health;
    [SerializeField] private GameObject gameOverText;
    private GameObject player;
    //[SerializeField] private Text restartText;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        //restartText.gameObject.SetActive(false);
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

      //  restartText.gameObject.SetActive(true);
    }
}
