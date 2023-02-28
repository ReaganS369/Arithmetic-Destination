using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    public Text resultText;
    private float operand1 = 0f;
    private float operand2 = 0f;
    private float result = 0f;
    private string operation;

    private void Start()
    {
        resultText.resizeTextForBestFit = true;
    }
    // Called when a number button is clicked
    public void NumberButtonClick(string number)
    {
        if (operation == null)
        {
            operand1 = operand1 * 10f + float.Parse(number);
            resultText.text = operand1.ToString();
        }
        else
        {
            operand2 = operand2 * 10f + float.Parse(number);
            resultText.text = operand2.ToString();
        } // append new number and space to existing text
    }

    // Called when an operator button is clicked
    public void OperatorButtonClick(string op)
    {
        operation = op;
        resultText.text = operation; // append operator and spaces to existing text
    }

    // Called when the equals button is clicked
    public void EqualsButtonClick()
    {
        if (operation == "+")
        {
            result = operand1 + operand2;
        }
        else if (operation == "-")
        {
            result = operand1 - operand2;
        }
        else if (operation == "x")
        {
            result = operand1 * operand2;
        }
        else if (operation == "/")
        {
            result = operand1 / operand2;
        }
        resultText.text = result.ToString();
    }

    // Called when the clear button is clicked
    public void ClearButtonClick()
    {
        operand1 = 0f;
        operand2 = 0f;
        result = 0f;
        operation = null;
        resultText.text = "";
    }
}
