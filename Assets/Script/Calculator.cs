using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;

public class Calculator : MonoBehaviour
{
    //[SerializeField] private GameObject player;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] private Text resultText;
    [SerializeField] private Text detector;

    private float firstNumber;
    private float secondNumber;
    private float result;
    private string operation;

    private Vector3Int currentTile;
    private bool enterToggle = false;
    private float tileSize = 1f; // the size of each tile in units

    private Transform[,] tiles;

    private void Start()
    {
        Clear();

        currentTile = tilemap.WorldToCell(transform.position);
    }

    public void DChange()
    {
        // toggle direction
        enterToggle = !enterToggle;

        // update the value of the detector
        if (enterToggle)
            {
                    detector.text = "Y";
                }
                else
                {
                    detector.text = "X";
                }
    }

    private void Move(Vector3Int direction)
    {
        Vector3Int targetTile = currentTile + direction;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(tilemap.GetCellCenterWorld(targetTile), tileSize / 2);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                return;
            }
            else if (collider.CompareTag("Trap"))
            {
                Die();
            }
        }
        if (tilemap.HasTile(targetTile))
        {
            transform.position = tilemap.GetCellCenterWorld(targetTile);
            currentTile = targetTile;
        }
    }

    private void Die()
    {
        bodyType = RigidbodyType2D.Static;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    {
        if (displayText.text.Length > 0)
        {
            displayText.text = displayText.text.Substring(0, displayText.text.Length - 1);
            if (displayText.text == "")
            {
                displayText.text = "";
                resultText.text = "";
            }
        }
    }

    public void Equal()
    {
            int result = (int)CalculateResult(); ;
        /*if (Mathf.Abs(result) >= numberTilesX || Mathf.Abs(result) >= numberTilesY)
        {
            result = 0;
        }*/

        resultText.text = Mathf.Ceil(result).ToString();
        displayText.text = firstNumber.ToString() + operation + secondNumber.ToString() + "=" + Mathf.Ceil(result).ToString();
        firstNumber = result; // set the result as the new first number
        secondNumber = 0;
        operation = "";

        //Move(result % tileSize, result / tileSize);
        if (enterToggle)
        {
            Move(new Vector3Int(0, result, 0)); // move down
        }
        else
        {
            Move(new Vector3Int(result, 0, 0)); // move right
        }
    }

    public void SetNumber(string number)
    { if (operation == "") 
        {
        firstNumber = float.Parse(number);
        //firstNumber = Mathf.Clamp(firstNumber, -9999.0f, 9999.0f);
        displayText.text = firstNumber.ToString();
        resultText.text = firstNumber.ToString();
        }
        else 
        {
        secondNumber = float.Parse(number);
        //secondNumber = Mathf.Clamp(secondNumber, -9999.0f, 9999.0f);//limit the digit to 4 digit number
        displayText.text = firstNumber.ToString() + operation + secondNumber.ToString();
        result = CalculateResult();
        resultText.text = Mathf.Ceil(result).ToString();
        }
    }

    public void SetOperation(string op)
    {
        operation = op;
        displayText.text = firstNumber.ToString() + operation;
    }

    private float CalculateResult()
    {
        float result = 0;
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