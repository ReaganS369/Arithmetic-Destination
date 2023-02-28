using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public static bool LevelCompleteScreen = false;
   
    public void Restart()
    {
        LevelCompleteScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        LevelCompleteScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        LevelCompleteScreen = false;
        SceneManager.LoadScene("Menu");
    }
}