using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float zoomSpeed = 10.0f;
    public float followSpeed = 0.8f;
    public float minZoomDistance = 1.0f; // Distância mínima de zoom
    public float maxZoomDistance = 20.0f; // Distância máxima de zoom

    private Vector3 lastMousePosition;
    public Transform targetToFollow;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.RotateAround(targetToFollow.position, Vector3.up, delta.x * rotationSpeed * Time.deltaTime);
            transform.RotateAround(targetToFollow.position, transform.right, -delta.y * rotationSpeed * Time.deltaTime);
            lastMousePosition = Input.mousePosition;
        }

        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        Vector3 zoomVector = transform.forward * zoomAmount;

        // Ajustar a distância de zoom
        if (targetToFollow != null)
        {
            float currentZoomDistance = Vector3.Distance(transform.position, targetToFollow.position);
            float newZoomDistance = Mathf.Clamp(currentZoomDistance + zoomAmount, minZoomDistance, maxZoomDistance);

            // Ajustar a variável maxZoomDistance
            maxZoomDistance = newZoomDistance;

            transform.position += zoomVector;
        }

        if (targetToFollow != null)
        {
            Vector3 desiredPosition = targetToFollow.position - transform.forward * maxZoomDistance;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

    }

    public void FocusAndFollow(Transform target)
    {
        targetToFollow = target;
        lastMousePosition = Input.mousePosition;
    }

    public void StopFollowing()
    {
        targetToFollow = null;
    }
}
