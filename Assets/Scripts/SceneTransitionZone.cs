using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitionZone : MonoBehaviour
{
    public string sceneToLoad = "Kagabosjourney";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}