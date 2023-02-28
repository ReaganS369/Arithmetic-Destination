using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    public static bool GameBackMenu = false;

    public void LoadMenu()
    {
        GameBackMenu = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
