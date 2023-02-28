using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameOverScreen = false;
    
    public void Restart()
    {
        Time.timeScale = 1.0f;
        GameOverScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        GameOverScreen = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        GameOverScreen = false;
        SceneManager.LoadScene("Menu");
    }
}
