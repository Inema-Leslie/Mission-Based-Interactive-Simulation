using UnityEngine;
using TMPro;

// This script keeps the book count text updated
public class BookCountUI : MonoBehaviour
{
    
    public TMP_Text bookCountText;

    void Update()
    {
        // Check if GameManager exists
        if (GameManager.Instance != null)
        {
            // Update the text every frame
            bookCountText.text = "Books: " + GameManager.Instance.totalBooks;
        }
    }
}