using UnityEngine;
using UnityEngine.SceneManagement;

// When Kagabo walks into this zone, load the next scene
public class SceneTransitionZone : MonoBehaviour
{
    public string sceneToLoad = "TheJourney";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}