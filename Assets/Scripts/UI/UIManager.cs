using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject activityAndTime;

    [Header("Activity")]
    public TextMeshProUGUI activity;
    public TMP_InputField activityField;
    public int activityCharacterLimit = 24;

    [Header("Timer")]
    public TextMeshProUGUI timer;
    public TMP_InputField timerField;
    public int timerCharacterLimit = 5;
    private float timeRemaining;

    [Header("Button")]
    public Button submitButton;

    private void Start()
    {
        // Sets up character limit
        activityField.characterLimit = activityCharacterLimit;
        timerField.characterLimit = timerCharacterLimit;

        timerField.characterValidation = TMP_InputField.CharacterValidation.Integer; // Only take Numbers

        activityAndTime.SetActive(false);
    }

    private void Update()
    {
        int wordCount = activityField.text.Length;
        int minuteCount = timerField.text.Length;

		// gray out the submit button if all the fields are not filled
        if (wordCount > 0 && minuteCount > 0)
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;
        }

        timeRemaining -= Time.deltaTime; // count down the timer
        StopWatch(); // call the stopwatch system
    }

    private void SetActivity()
    {
        activity.text = activityField.text;
    }

    private void StopWatch()
    {

        int roundedSeconds = Mathf.FloorToInt(timeRemaining); // round the seconds to integers because float is too much numbers
        int minuteResult = roundedSeconds / 60; // divide the seconds by 60 to make minutes

        string printResult; // this is a string to be assigned what to print later
        string unitType; // will be used to change "minutes" to "minute" if is only 1 minute (grammar stuff)

        if (roundedSeconds < 0) roundedSeconds = 0; // so it doesn't go negative
        if (roundedSeconds <= 60)
        {
            printResult = roundedSeconds.ToString();
            //unitType = " seconds left!";
            if (roundedSeconds > 1) unitType = " seconds left";
            else unitType = " second left";
        }
        else
        {
            printResult = minuteResult.ToString();
            if (minuteResult > 1) unitType = " minutes left"; else unitType = " minute left";
        }

        timer.text = printResult + unitType;
    }

    private void SetTimer()
    {
        timeRemaining = float.Parse(timerField.text) * 60;
    }

    public void Submit()
    {
        activityAndTime.SetActive(true);
        SetActivity();
        SetTimer();
    }
}
