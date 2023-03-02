using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TMP_Text resultText;

    private float result;
    private float input1;
    private float input2;
    private string operation;

    public void AddNumber(int number)
    {
        if (operation == null)
        {
            input1 += number;
            resultText.text = input1.ToString();
        }
        else
        {
            input2 += number;
            resultText.text = input1.ToString() + operation + input2.ToString();
        }
        result = 0;
    }

    public void SetOperation(string op)
    {
        if (input1 != 0 && operation == null)
        {
            operation = op;
            resultText.text += operation;
        }
    }

    public void Calculate()
    {
        switch (operation)
        {
            case "+":
                result = input1 + input2;
                break;
            case "-":
                result = input1 - input2;
                break;
            case "×":
                result = input1 * input2;
                break;
            case "÷":
                result = input1 / input2;
                break;
        }

        resultText.text = result.ToString();

        input1 = result;
        input2 = 0;
        operation = null;
    }

    public void Delete()
    {
        if (resultText.text.Length > 0)
        {
            resultText.text = resultText.text.Substring(0, resultText.text.Length - 1);
            if (resultText.text == "")
            {
                resultText.text = "0";
            }
        }
    }
}

