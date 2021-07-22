using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SetCurrentTime : MonoBehaviour
{
    public enum HourFormatEnum { Format12, Format24};
    public HourFormatEnum hourFormat = HourFormatEnum.Format12;

    public string hours, minutes;

    private TextMeshProUGUI clockText;

    private void Start()
    {
        clockText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int refHours = System.DateTime.Now.Hour;
        int refMinutes = System.DateTime.Now.Minute;
        string ampm;
        string minzero;

        if(refHours > 12 && hourFormat == HourFormatEnum.Format12)
        {
            refHours -= 12;
            ampm = "PM";
        }
        else ampm = "AM";

        if (refMinutes < 10) minzero = "0"; else minzero = "";

        if(hourFormat == HourFormatEnum.Format24) ampm = "";

        hours = refHours.ToString();
        minutes = refMinutes.ToString();

        clockText.text = hours + ":" + minzero + minutes + " " + ampm;
    }
}
