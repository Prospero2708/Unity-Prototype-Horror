using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform PlayerCam;
    [SerializeField] private float sensitive;
    [SerializeField] private float cameraSmoothFactor = 40f;
    private float targetRotationX = 0f; // target coordinates (x)
    private float targetRotationY = 0f; // target coordinates (y)
    private float currentRotationX = 0f; // current smoothed coordinates (x)
    private float currentRotationY = 0f; // current smoothed coordinates (y)
    [SerializeField] private InputRead inputReader; // script, what read input from player

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor into center
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mouseDelta = inputReader.MouseDelta;

        if (mouseDelta.sqrMagnitude > 0.0001f) // handle mouse movement
        {
            targetRotationY += mouseDelta.x * sensitive;
            targetRotationX -= mouseDelta.y * sensitive;
            targetRotationX = Mathf.Clamp(targetRotationX, -90f, 90f); // clamp vertical rotation between -90 and 90 degrees
        }

        // if there is a noticeable difference between target and current rotation
        if (Mathf.Abs(currentRotationY - targetRotationY) > 0.001f || Mathf.Abs(currentRotationX - targetRotationX) > 0.001f)
        {
            float t = 1f - Mathf.Exp(-cameraSmoothFactor * Time.deltaTime);

            currentRotationY = Mathf.Lerp(currentRotationY, targetRotationY, t);
            currentRotationX = Mathf.Lerp(currentRotationX, targetRotationX, t);

            transform.localRotation = Quaternion.Euler(0f, currentRotationY, 0f);

            if (PlayerCam != null)
            {
                PlayerCam.localRotation = Quaternion.Euler(currentRotationX, 0f, 0f);
            }
        }
    }
}