using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // Car to follow
    public Vector3 offset = new Vector3(0, 5, -10); // Camera offset
    public float mouseSensitivity = 2f;

    private float yaw = 0f;
    private float pitch = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to screen
    }

    void LateUpdate()
    {
        // Mouse input
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -20f, 45f); // Limit vertical look

        // Rotate camera around target
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position + Vector3.up * 1.5f); // Look at car center
    }
}
