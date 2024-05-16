using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("Game");
    }

    public void exitGame(){
        Application.Quit();
    }
    public void Easy(int val)
    {
        if(val == 0)
        {
            PlayerPrefs.SetInt("Difficulty", 1);
        }
    }
    public void Medium(int val)
    {
        if (val == 1)
        {
            PlayerPrefs.SetInt("Difficulty", 2);
        }
    }
    public void Hard(int val)
    {
        if (val == 2)
        {
            PlayerPrefs.SetInt("Difficulty", 3);
        }
    }
}
