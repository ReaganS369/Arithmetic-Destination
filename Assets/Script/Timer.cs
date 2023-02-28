using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public bool timerIsRunning = false;

    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private Text timeText;

    public GameObject gameOverMenuUI;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        gameOverMenuUI = GameObject.Find("gameOverMenuUI");
        timerIsRunning = true;

    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                gameOverMenuUI.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            timerIsRunning = false;
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 10;
        timeText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }
}

