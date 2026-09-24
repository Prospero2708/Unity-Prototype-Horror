using UnityEngine;
using UnityEngine.InputSystem;

public class interaction : MonoBehaviour
{
    [SerializeField] private InputActionAsset inp;
    [SerializeField] private Transform PlayerCam;
    [SerializeField] private InputRead inputReader;
    private float MaxDistance = 10f;

    private void OnEnable()
    {
        if (inputReader != null)
        {
            inputReader.Interact += OnInteractPressed;
        }
    }

    private void OnDisable()
    {
        if (inputReader != null)
        {
            inputReader.Interact -= OnInteractPressed;
        }
    }

    private void OnInteractPressed()
    {
        Vector3 rayStart = PlayerCam.position;
        Vector3 rayDirection = PlayerCam.forward;

        if (Physics.Raycast(rayStart, rayDirection, out RaycastHit hitInfo, MaxDistance))
        {
            Debug.Log(hitInfo.collider.name);
        }
    }
}