﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int min = 1;
    private int max = 100;
    private int guess;

    private void Start()
    {
        WriteMessage("Number Wizard");
        WriteMessage("Pick a number between 1 and 100");
        NextGuess();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess + 1;
            NextGuess();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess + 1;
            NextGuess();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            WriteMessage("Fertig");
        }
    }
        
    private void WriteMessage(string msg)
    {
        Debug.Log(msg);
    }

    private void NextGuess()
    {
        guess = (min + max) / 2;
        WriteMessage("Is your number higher or lower than ..." + guess);
    }
}