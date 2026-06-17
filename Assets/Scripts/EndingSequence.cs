using UnityEngine;
using System.Collections;

public class EndingSequence : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public Transform kagabo;
    public Transform billboard;
    public LineRenderer pointBeam;
    public Transform handPoint;
    public GameObject mainCamera;
    public GameObject endCamera;
    public GameObject billboardPanel;

    [Header("Timing")]
    public float pointDelay = 0.3f;
    public float beamHold = 1f;

    private bool started = false;

    private void Start()
    {
        if (pointBeam != null) pointBeam.enabled = false;
        if (endCamera != null) endCamera.SetActive(false);
        if (billboardPanel != null) billboardPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (started) return;
        if (other.CompareTag("Player"))
        {
            started = true;
            StartCoroutine(PlayEnding());
        }
    }

    private IEnumerator PlayEnding()
    {
        if (playerController != null) playerController.SetInputEnabled(false);

        if (kagabo != null && billboard != null)
        {
            Vector3 dir = billboard.position - kagabo.position;
            dir.y = 0;
            kagabo.rotation = Quaternion.LookRotation(dir);
        }

        yield return new WaitForSeconds(pointDelay);
        if (pointBeam != null && handPoint != null && billboard != null)
        {
            pointBeam.enabled = true;
            pointBeam.SetPosition(0, handPoint.position);
            pointBeam.SetPosition(1, billboard.position);
        }

        yield return new WaitForSeconds(beamHold);

        if (mainCamera != null) mainCamera.SetActive(false);
        if (endCamera != null) endCamera.SetActive(true);

        yield return new WaitForSeconds(1f);
        if (billboardPanel != null) billboardPanel.SetActive(true);
    }
}