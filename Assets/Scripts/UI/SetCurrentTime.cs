using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SetCurrentTime : MonoBehaviour
{
	// HourFormat is to set the time format to 12 hour or 24 hour format
    public enum HourFormatEnum { Format12, Format24};
    public HourFormatEnum hourFormat = HourFormatEnum.Format12;

    public string hours, minutes;

    private TextMeshProUGUI clockText;

    private void Start()
    {
		// bind the clockText to the component in the object this script is assigned to
        clockText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int refHours = System.DateTime.Now.Hour;
        int refMinutes = System.DateTime.Now.Minute;
        string ampm; // edited later on to show AM or PM
        string minzero; // used to add a zero in front if minute is less than 10

        if(refHours > 12 && hourFormat == HourFormatEnum.Format12)
        {
			// if time format is 12 hours..
			// if hours is more than 12 then substract by 12
			// set ending to PM
            refHours -= 12;
            ampm = "PM";
        }
        else ampm = "AM"; // if not then its morning AM

        if (refMinutes < 10) minzero = "0"; else minzero = ""; // if minute is less than 10 then add a zero to make it two digits

        if(hourFormat == HourFormatEnum.Format24) ampm = ""; // if time format is 24 hours.. then you don't really need the AM or PM

		// this just makes them into a string to print
        hours = refHours.ToString();
        minutes = refMinutes.ToString();

        clockText.text = hours + ":" + minzero + minutes + " " + ampm; // combine it all together and set it to display
    }
}
