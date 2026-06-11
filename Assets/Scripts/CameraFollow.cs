using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 50f;
    public float distance = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        // Position camera above and slightly behind Kagabo
        transform.position = new Vector3(
            target.position.x,
            target.position.y + height,
            target.position.z - distance
        );

        // Look at Kagabo
        transform.LookAt(target.position);
    }
}