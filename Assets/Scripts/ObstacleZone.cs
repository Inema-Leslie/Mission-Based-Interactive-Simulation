using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObstacleZone : MonoBehaviour
{
    [Header("Obstacle Info")]
    public string obstacleTitle = "Obstacle Title";
    [TextArea] public string awarenessMessage = "Something blocked the path.";
    public int booksLost = 3;

    [Header("Optional: Objects to reveal on activation")]
    public GameObject[] objectsToReveal;

    [Header("UI References")]
    public GameObject popupPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI booksLostText;
    public Button continueButton;

    private bool hasActivated = false;
    private PlayerController playerController;

    private void Start()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
        if (continueButton != null) continueButton.onClick.AddListener(HidePopup);
        playerController = Object.FindAnyObjectByType<PlayerController>();
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;

       
        foreach (GameObject obj in objectsToReveal)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    public void Activate()
    {
        if (hasActivated) return;
        hasActivated = true;
        ShowPopup();
    }

    private void ShowPopup()
    {
        if (playerController != null) playerController.SetInputEnabled(false);

        
        foreach (GameObject obj in objectsToReveal)
        {
            if (obj != null) obj.SetActive(true);
        }

        if (titleText != null) titleText.text = obstacleTitle;
        if (messageText != null) messageText.text = awarenessMessage;
        if (booksLostText != null)
        {
            if (GameManager.Instance != null) GameManager.Instance.LoseBooks(booksLost);
            booksLostText.text = $"-{booksLost} books lost";
        }
        if (popupPanel != null) popupPanel.SetActive(true);
    }

    private void HidePopup()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
        if (playerController != null) playerController.SetInputEnabled(true);
    }
}