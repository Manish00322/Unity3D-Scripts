using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothSpeed = 0.125f; // The smoothness of camera movement
    public Vector3 offset; // The offset from the target position

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Use SmoothDamp to smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Make the camera look at the target object
        transform.LookAt(target);
    }
}
