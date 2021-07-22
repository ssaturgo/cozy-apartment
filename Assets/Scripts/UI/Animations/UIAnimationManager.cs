using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [Header("Setup")]
    public float toggleCooldown = 0.3f;
    private float cooldownTimeRemaining;

    [Header("Apartment Animation")]
    public GameObject ApartmentObject;
    public float ApartmentAnimationTime = 0.5f;

    [Header("UI Animation")]
    public GameObject UIObject;
    public float UIAnimationTime = 0.5f;

    private bool toggle;

    private void Update()
    {
        if(cooldownTimeRemaining > 0) cooldownTimeRemaining -= Time.deltaTime;
    }
    public void UIToggle()
    {
        if (cooldownTimeRemaining > 0) return;
        toggle = !toggle;
        if (toggle)
        { // Show UI
            LeanTween.scale(ApartmentObject, new Vector3(0, 0, 0), ApartmentAnimationTime).setOnComplete(DisableApartment);
            UIObject.SetActive(true);
            LeanTween.scale(UIObject, new Vector3(0, 0, 0), 0);
            LeanTween.scale(UIObject, new Vector3(1, 1, 1), UIAnimationTime);
            cooldownTimeRemaining = toggleCooldown;
        }
        else if (!toggle)
        { // Show Apartment
            LeanTween.scale(UIObject, new Vector3(0, 0, 0), ApartmentAnimationTime).setOnComplete(DisableUI);
            ApartmentObject.SetActive(true);
            LeanTween.scale(ApartmentObject, new Vector3(0, 0, 0), 0);
            LeanTween.scale(ApartmentObject, new Vector3(1, 1, 1), ApartmentAnimationTime);
            cooldownTimeRemaining = toggleCooldown;
        }
        else return;
    }

    private void DisableApartment()
    {
        ApartmentObject.SetActive(false);
    }
    private void DisableUI()
    {
        UIObject.SetActive(false);
    }
}
