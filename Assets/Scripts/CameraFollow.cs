using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;        // Player transform to follow

    [Header("Camera Settings")]
    public float smoothSpeed = 0.125f; // How quickly the camera catches up
    public Vector3 offset;             // Offset from the player (e.g., (0, 0, -10))

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position = player position + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply position
        transform.position = smoothedPosition;
    }
}