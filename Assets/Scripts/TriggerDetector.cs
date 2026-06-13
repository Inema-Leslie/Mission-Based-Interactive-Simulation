using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private bool ready = false;

    private void Start()
    {
        StartCoroutine(EnableAfterFrame());
    }

    private System.Collections.IEnumerator EnableAfterFrame()
    {
        yield return null;
        ready = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit: " + other.name);   

        if (!ready) return;

        ObstacleZone zone = other.GetComponent<ObstacleZone>();
        if (zone != null)
        {
            zone.Activate();
        }
    }
}