//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI displayText; 
    public Text resultText; 

    private float firstNumber;
    private float secondNumber;
    private float result;
    private string operation;

    void Start()
    {
       Clear(); // clear inputs on start
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
        result = CalculateResult();
        if (result > 9 || result < -9) // if the result is out of range, set it to 0
        {
            result = 0;
        }
        resultText.text = Mathf.Ceil(result).ToString();
        displayText.text = firstNumber.ToString() + operation + secondNumber.ToString() + "=" + Mathf.Ceil(result).ToString();
        firstNumber = result; // set the result as the new first number
        secondNumber = 0;
        operation = "";
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
