using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private bool isCountingDown = true;
    public TMP_Text timerText; // Use TMP_Text instead of Text

    public void Start()
    {
        timerText.text = timer.ToString(); // Initialize the text to show the starting value
    }

    public void Update()
    {
        if (isCountingDown)
        {
            timer += Time.deltaTime;
            if (timer >= 60f)
            {
                isCountingDown = false;
                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 30f)
            {
                isCountingDown = true;
                timer = 0f;
            }
        }

        // Set the text property of the TMP Text element to the timer value
        timerText.text = timer.ToString("F2");
    }
}