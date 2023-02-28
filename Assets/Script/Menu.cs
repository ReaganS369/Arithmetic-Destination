using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GamePlay = false;
    
    public void Play()
    {
        GamePlay = false;
        SceneManager.LoadScene("Level 1");
    }

    public void Setting()
    {
        GamePlay = false;
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quitting...");
        Application.Quit();
    }
}
