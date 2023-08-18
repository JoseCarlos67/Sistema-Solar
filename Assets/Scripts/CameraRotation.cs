using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    private Vector3 lastMousePosition;
    public float zoomSpeed = 10.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.RotateAround(Vector3.zero, Vector3.up, delta.x * rotationSpeed * Time.deltaTime);
            transform.RotateAround(Vector3.zero, transform.right, -delta.y * rotationSpeed * Time.deltaTime);
            lastMousePosition = Input.mousePosition;
        }

        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        Vector3 zoomVector = transform.forward * zoomAmount;
        transform.position += zoomVector;

    }
}
