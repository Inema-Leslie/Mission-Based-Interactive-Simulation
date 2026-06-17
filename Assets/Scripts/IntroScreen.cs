using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    public GameObject introPanel;

    public void MeetKagabo()
    {
        introPanel.SetActive(false);
    }
}