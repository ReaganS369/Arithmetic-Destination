using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60; // Set the initial time remaining in seconds
    [SerializeField] private Text timerText;
    public bool timerIsRunning = true; // Whether the timer should be running or not
    [SerializeField] private GameObject OverMenuUI;
    [SerializeField] private float startBlink = 5f;
    [SerializeField] private float blinkSpeed = 0.5f;
    [SerializeField] private Outline outline;

    private IEnumerator Blink()
    {
        outline.enabled = true;
        while (timerIsRunning && timeRemaining <= startBlink)
        {
            outline.enabled = !outline.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        outline.enabled = true;
    }

    void GameOver()
    {
        OverMenuUI.SetActive(true);
        timerIsRunning = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
            UpdateTimerText();
            if (timeRemaining <= startBlink)
            {
                StartCoroutine(Blink());
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        int milliseconds = Mathf.FloorToInt((timeRemaining - Mathf.FloorToInt(timeRemaining)) * 99);
        timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }
}
