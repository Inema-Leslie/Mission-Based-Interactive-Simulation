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
    public GameObject endCamera;                
    public GameObject billboardPanel;           

    [Header("Timing")]
    public float pointDelay = 1f;     
    public float beamHold = 1.5f;     
    public float rotateSpeed = 3f;

    private bool started = false;

    private void Start()
    {
        // Everything hidden/off at start
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
        // 1. Stop the player
        if (playerController != null) playerController.SetInputEnabled(false);

        
        if (kagabo != null && billboard != null)
        {
            Vector3 dir = billboard.position - kagabo.position;
            dir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            float t = 0;
            while (t < 1f)
            {
                kagabo.rotation = Quaternion.Slerp(kagabo.rotation, targetRot, t);
                t += Time.deltaTime * rotateSpeed;
                yield return null;
            }
        }

        
        yield return new WaitForSeconds(pointDelay);
        if (pointBeam != null && handPoint != null && billboard != null)
        {
            pointBeam.enabled = true;
            pointBeam.SetPosition(0, handPoint.position);
            pointBeam.SetPosition(1, billboard.position);
        }

        
        yield return new WaitForSeconds(beamHold);

        
        if (endCamera != null) endCamera.SetActive(true);

       
        yield return new WaitForSeconds(1f);
        if (billboardPanel != null) billboardPanel.SetActive(true);
    }
}