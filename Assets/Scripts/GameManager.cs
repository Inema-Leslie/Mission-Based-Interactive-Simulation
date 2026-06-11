using UnityEngine;
using UnityEngine.SceneManagement;

// GameManager keeps track of the game state
// It persists between scenes (doesn't get destroyed)
public class GameManager : MonoBehaviour
{
    // This lets other scripts access GameManager easily
    public static GameManager Instance;

    // How many books Kagabo is carrying
    public int totalBooks = 30;

    void Awake()
    {
        // Make sure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // don't destroy when loading new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to go to the next scene
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    // Call this to lose some books
    public void LoseBooks(int amount)
    {
        totalBooks = totalBooks - amount;
        if (totalBooks < 0) totalBooks = 0;
        Debug.Log("Books remaining: " + totalBooks);
    }
}