using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [Header("Toggle Cooldown")] // to prevent weird interactions with spam clicking
    public float toggleCooldown = 0.3f; // must be equal to animation time or else it wouldn't work
    private float cooldownTimeRemaining;

    [Header("Apartment Animation")]
    public GameObject ApartmentObject;
    public float ApartmentAnimationTime = 0.5f;

    [Header("UI Animation")]
    public GameObject UIObject;
    public float UIAnimationTime = 0.5f;

    private bool toggle; // if true show the StopwatchUI

    private void Update()
    {
		// check if cooldown is more than 0 if so count down..
		// used if statement to stop it from going negative
		// you don't really have to prevent it from going negative.. but maybe in the future I want to show it
        if(cooldownTimeRemaining > 0) cooldownTimeRemaining -= Time.deltaTime;
    }


    public void UIToggle() // bind this with button to trigger UI on/off
    {
		// the idea is :
		// if button is not on cooldown. when pressed, switch  between show UI or show apartment

        if (cooldownTimeRemaining > 0) return; // if still on cooldown just skip everything

        toggle = !toggle; // alternate between UI on/off

        if (toggle) // Show UI
		{
            LeanTween.scale(ApartmentObject, new Vector3(0, 0, 0), ApartmentAnimationTime).setOnComplete(DisableApartment);
            UIObject.SetActive(true);
            LeanTween.scale(UIObject, new Vector3(0, 0, 0), 0);
            LeanTween.scale(UIObject, new Vector3(1, 1, 1), UIAnimationTime);
            cooldownTimeRemaining = toggleCooldown;
        }
        else if (!toggle) // Show Apartment
		{
            LeanTween.scale(UIObject, new Vector3(0, 0, 0), ApartmentAnimationTime).setOnComplete(DisableUI);
            ApartmentObject.SetActive(true);
            LeanTween.scale(ApartmentObject, new Vector3(0, 0, 0), 0);
            LeanTween.scale(ApartmentObject, new Vector3(1, 1, 1), ApartmentAnimationTime);
            cooldownTimeRemaining = toggleCooldown;
        }
        else return; // not really needed.. but just in case
    }

	// both of these are just called to disable the UI or Apartment
    private void DisableApartment()
    {
        ApartmentObject.SetActive(false);
    }
    private void DisableUI()
    {
        UIObject.SetActive(false);
    }
}
