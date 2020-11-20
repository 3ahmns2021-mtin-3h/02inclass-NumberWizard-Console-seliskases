using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public TMP_InputField inputNumber, inputMin, inputMax;
    public TextMeshProUGUI textField;

    private float number, min, max, range, maxCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            number = float.Parse(inputNumber.text);
            min = float.Parse(inputMin.text);
            max = float.Parse(inputMax.text);
            range = max - min;

            if(number>=min && number <= max)
            {
                WriteCount();
            }
            else
            {
                Debug.LogWarning("Your number is not within your given Range");
            }

        }
    }

    private void WriteCount()
    {
        textField.text = CalculateCount(min, max).ToString();
    }

    private int CalculateCount(float tempMin, float tempMax)
    {
        float guess;
        int count=0;

        for(int n = 1; n <= CalculateMax(); n++)
        {
            count = n;
            guess = Mathf.FloorToInt((tempMin + tempMax) / 2);

            if(guess > number)
            {
                tempMax = guess;
            }

            if(guess < number)
            {
                tempMin = guess;
            }

            if(guess == number)
            {
                break;
            }
        }
        return(count);
    }

    private float CalculateMax()
    {
        float maxCount = Mathf.Ceil(Mathf.Log(range, 2));
        return(maxCount);
    }
}
