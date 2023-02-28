using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public static bool GamePause = false;
    [SerializeField] private AudioSource finishSound;

    public GameObject levelCompleteMenuUI;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private void Start()
    {
        levelCompleteMenuUI = GameObject.Find("levelCompleteMenuUI");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            anim.SetTrigger("Finish");
            finishSound.Play();
            rb.bodyType = RigidbodyType2D.Static;
            levelCompleteMenuUI.SetActive(true);
            GamePause = true;
            Invoke("LevelComplete", 4f);
        }
    }

}
