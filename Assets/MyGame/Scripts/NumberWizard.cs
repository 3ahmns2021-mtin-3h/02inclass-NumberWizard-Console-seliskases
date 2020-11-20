using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour
{
    public GameObject backButton;
    public TextMeshProUGUI textField;
    public int min = 1;
    public int max = 100;

    private int guess, tempGuess;

    private void Start()
    {
        WriteMessage("Number Wizard");
        WriteMessage("Pick a number between 1 and 100");
        NextGuess();
    }

    private void Update()
    {
        int value = Convert.ToInt32(GameManager.rangeIsChanging);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;
            NextGuess();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess - 1;
            NextGuess();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            WriteMessage("Fertig");
        }
    }
        
    private void WriteMessage(string msg)
    {
        textField.text = msg;
    }

    private void NextGuess()
    {
        guess = (min + max) / 2;

        if(guess != tempGuess)
        {
            tempGuess = guess;
            WriteMessage("Is your number higher or lower than " + guess + "?");
        }
        else
        {
            if (GameManager.selfDestruction)
            {
                backButton.SetActive(false);
                WriteMessage("You lied!");
                StartCoroutine(QuitGame());
            }
            else
            {
                WriteMessage("The number can't be within your given Range!");
            }
        }
    }

    private IEnumerator QuitGame()
    {
        print("destructing");
        float time = 6;
        while (true)
        {
            time -= Time.deltaTime;

            if(time <= 5)
            {
                textField.text = Mathf.FloorToInt(time).ToString();
            }          

            if (time == 0)
            {
                Application.Quit();
                break;
            }
            yield return null;
        }
    }
}
