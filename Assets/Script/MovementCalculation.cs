using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MovementCalculation : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenuUI;
    [SerializeField] private GameObject levelCompleteMenuUI;

    [SerializeField] private int maxDigits = 4;
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Text resultText;
    [SerializeField] private Text detector;

    [SerializeField] private Animator anim;

    [SerializeField] private AudioSource moveSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource finishSound;

    [SerializeField] private Tilemap tilemap;

    [SerializeField] private Text upTilesText;
    [SerializeField] private Text rightTilesText;
    [SerializeField] private Text downTilesText;
    [SerializeField] private Text leftTilesText;

    private float firstNumber;
    private float secondNumber;
    private float result;
    private string operation;

    private Vector3Int currentTile;
    private bool enterToggle = false;
    private float tileSize = 1f;

    private static bool gameOver = false;
    private static bool levelComplete = false;

    private Transform[,] tiles;

    private void Start()
    {
        Clear();
        UpdateCurrentTile();
    }

    void Update()
    {
        UpdateCurrentTile();

        CountTiles(new Vector3Int(0, 1, 0), upTilesText); // up
        CountTiles(new Vector3Int(1, 0, 0), rightTilesText); // right
        CountTiles(new Vector3Int(0, -1, 0), downTilesText); // down
        CountTiles(new Vector3Int(-1, 0, 0), leftTilesText); // left
    }

    private void DeathMenu()
    {
        gameOver = true;
        gameOverMenuUI.SetActive(true);
    }

    private void LevelCompleteMenu()
    {
        levelComplete = true;
        levelCompleteMenuUI.SetActive(true);
    }

    private void OffBool()
    {
        anim.SetBool("move", false);
    }

    private void UpdateCurrentTile()
    {
        currentTile = tilemap.WorldToCell(transform.position);
    }

    private void CountTiles(Vector3Int direction, Text text)
    {
        int count = 0;
        Vector3Int targetTile = currentTile + direction;

        while (tilemap.HasTile(targetTile))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(tilemap.GetCellCenterWorld(targetTile), tileSize / 2);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    text.text = count.ToString();
                    return;
                }
            }
            count++;
            targetTile += direction;
        }

        text.text = count.ToString();
    }

    private void DChange()
    {
        enterToggle = !enterToggle;

        if (enterToggle)
        {
            detector.text = "Y";
        }
        else
                {
                    detector.text = "X";
                }
    }

    public void Move(Vector3Int direction)
    {
        moveSound.Play();
        Vector3Int targetTile = currentTile + direction;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tilemap.GetCellCenterWorld(targetTile), tileSize / 2);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Wall") || collider.CompareTag("Water"))
            {
                return;
            }
        }

        Vector3 start = transform.position;
        Vector3 end = tilemap.GetCellCenterWorld(targetTile);
        RaycastHit2D[] hits = Physics2D.LinecastAll(start, end);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("water"))
            {
                return;
            }
            if (hit.collider.CompareTag("Trap"))
            {
                anim.SetTrigger("death");
                deathSound.Play();
            }
            if (hit.collider.CompareTag("Finish"))
            {
                anim.SetTrigger("finish");
                finishSound.Play();
                levelCompleteMenuUI.SetActive(true);
            }
        }

        if (tilemap.HasTile(targetTile))
        {
            transform.position = tilemap.GetCellCenterWorld(targetTile);
            currentTile = targetTile;
        }
    }

    public void Clear()
    {
        firstNumber = 0;
        secondNumber = 0;
        result = 0;
        operation = "";
        displayText.text = "0";
        resultText.text = "0";
    }

    public void Delete()
    {//error in delete firstNumber
        int length = displayText.text.Length;
        if (length > 0)
        {
            displayText.text = displayText.text.Substring(0, length - 1);
            if (operation == "")
            {
                firstNumber = Mathf.Floor(firstNumber / 10);
                resultText.text = firstNumber.ToString();
            }
            else
            {
                secondNumber = Mathf.Floor(secondNumber / 10);
                result = CalculateResult();
                resultText.text = Mathf.Ceil(result).ToString();
            }
        }
    }

    public void Number(float number)
    {
        if (operation == "")
        {
            if (Mathf.Floor(Mathf.Log10(firstNumber) + 1) < maxDigits)
            {
                firstNumber = firstNumber * 10 + number;
            }

            displayText.text = firstNumber.ToString();
            resultText.text = firstNumber.ToString();
        }
        else
        {
            if (Mathf.Floor(Mathf.Log10(secondNumber) + 1) < maxDigits)
            {
                secondNumber = secondNumber * 10 + number;
            }

            displayText.text = firstNumber.ToString() + operation + secondNumber.ToString();
            result = CalculateResult();
            resultText.text = Mathf.Ceil(result).ToString();
        }
    }

    public void Operation(string op)
    {
        operation = op;
        displayText.text = firstNumber.ToString() + operation + secondNumber.ToString();
    }

    public void Equal()
    {
        int result = (int)CalculateResult(); ;
        if (firstNumber == 0 && secondNumber == 0 && operation == "")
        {
            DChange();
            return;
        }
        if (firstNumber == 0 && secondNumber == 0)
        {
            displayText.text = "0";
            return;
        }
        resultText.text = Mathf.Ceil(result).ToString();
        displayText.text = firstNumber.ToString() + operation + secondNumber.ToString() + "=" + Mathf.Ceil(result).ToString();
        
        firstNumber = 0; 
        secondNumber = 0;
        operation = "";

        if (enterToggle)
        {
            anim.SetBool("move", true);
            Move(new Vector3Int(0, result, 0)); // move down
        }
        else
        {
            anim.SetBool("move", true);
            Move(new Vector3Int(result, 0, 0)); // move right
        }
    }
    
    private float CalculateResult()
    {
        switch (operation)
        {
            case "+":
                return firstNumber + secondNumber;
            case "-":
                return firstNumber - secondNumber;
            case "×":
                return firstNumber * secondNumber;
            case "÷":
                if (secondNumber == 0) // prevent dividing by zero
                {
                    return 0;
                }
                else
                {
                    return firstNumber / secondNumber;
                }
            default:
                return 0;
        }
    }
}