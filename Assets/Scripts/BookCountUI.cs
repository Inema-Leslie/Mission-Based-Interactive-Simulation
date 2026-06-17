using UnityEngine;
using TMPro;


public class BookCountUI : MonoBehaviour
{
    
    public TMP_Text bookCountText;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            
            bookCountText.text = "Books: " + GameManager.Instance.totalBooks;
        }
    }
}