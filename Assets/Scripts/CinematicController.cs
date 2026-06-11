using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class CinematicController : MonoBehaviour
{
    [Header("Cinemachine Cameras")]
    [SerializeField] private CinemachineCamera aerialCam;
    [SerializeField] private CinemachineCamera followCam;

    [Header("Aerial Zoom Settings")]
    [SerializeField] private Transform kagaboTransform;
    [SerializeField] private float aerialHoldDuration = 4f;
    [SerializeField] private float zoomDuration = 3f;
    [SerializeField] private float aerialHeight = 120f;

    private bool _cinematicComplete = false;

    private void Start()
    {
        SetCameraWeights(aerialActive: true);
        StartCoroutine(RunAerialIntro());
    }

    private IEnumerator RunAerialIntro()
    {
        yield return new WaitForSeconds(aerialHoldDuration);
        yield return StartCoroutine(BlendToFollowCam());
        _cinematicComplete = true;
        OnCinematicComplete?.Invoke();
    }

    private IEnumerator BlendToFollowCam()
    {
        float elapsed = 0f;
        Vector3 startPos = aerialCam.transform.position;
        Vector3 endPos = kagaboTransform.position + Vector3.up * (aerialHeight * 0.3f);

        followCam.Priority = 20;
        aerialCam.Priority = 10;

        while (elapsed < zoomDuration)
        {
            float smoothT = Mathf.SmoothStep(0f, 1f, elapsed / zoomDuration);
            aerialCam.transform.position = Vector3.Lerp(startPos, endPos, smoothT);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void SetCameraWeights(bool aerialActive)
    {
        if (aerialCam != null) aerialCam.Priority = aerialActive ? 20 : 0;
        if (followCam != null) followCam.Priority = aerialActive ? 0 : 20;
    }

    public System.Action OnCinematicComplete;
    public bool IsCinematicComplete => _cinematicComplete;
}