using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoomController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector3 defaultPosition;
    Quaternion defaultRotation;

    Vector3 targetPosition;
    Quaternion targetRotation;

    void Start()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;

        targetPosition = defaultPosition;
        targetRotation = defaultRotation;
    }

    void Update()
    {
        HandleMouse();

        transform.position =
            Vector3.Lerp(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                moveSpeed * Time.deltaTime);
    }

    void HandleMouse()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                ClickableObject obj =
                    hit.collider.GetComponent<ClickableObject>();

                if (obj != null)
                {
                    targetPosition = obj.cameraAnchor.position;
                    targetRotation = obj.cameraAnchor.rotation;
                }
            }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            targetPosition = defaultPosition;
            targetRotation = defaultRotation;
        }
    }
}