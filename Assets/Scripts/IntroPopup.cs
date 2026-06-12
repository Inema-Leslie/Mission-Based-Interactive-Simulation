using UnityEngine;
using UnityEngine.UI;

public class IntroPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject continueButton; 

    void Start()
    {
        if (popupPanel != null)
            popupPanel.SetActive(true);
    }

    public void OnContinueClicked()
    {
        // Hide both the popup and the button
        if (popupPanel != null)
            popupPanel.SetActive(false);
        if (continueButton != null)
            continueButton.SetActive(false);
    }
}