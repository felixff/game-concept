using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (your player)
    public float smoothing = 5f; // How smoothly the camera catches up with its target movement
    public Vector3 offset; // The initial offset from the target

    void Start()
    {
        // Calculate initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a postion for the camera to move to.
        Vector3 targetCamPos = target.position + offset;
        // Smoothly interpolate between the camera's current position and its target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}