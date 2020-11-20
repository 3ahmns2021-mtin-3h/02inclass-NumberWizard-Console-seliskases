using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public TMP_InputField inputGuess, inputMin, inputMax;
    public TextMeshProUGUI textField;
    
    private float guess, min, max, range;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            guess = float.Parse(inputGuess.text);
            min = float.Parse(inputMin.text);
            max = float.Parse(inputMax.text);
            range = max - min;

            WriteCount();
        }
    }

    private void WriteCount()
    {
        textField.text = CalculateCount().ToString();
    }

    private float CalculateCount()
    {
        float maxCount = Mathf.Ceil(Mathf.Log(range, 2));
        return maxCount;
    }
}
