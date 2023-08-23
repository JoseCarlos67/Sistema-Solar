using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float zoomSpeed = 10.0f;
    public float followSpeed = 0.8f;
    public float minZoomDistance = 1.0f; // Distância mínima de zoom
    public float maxZoomDistance = 20.0f; // Distância máxima de zoom

    private Vector3 lastMousePosition;
    private Vector3 initialOffset;
    private float currentZoomDistance;

    public Transform targetToFollow;

    void Start()
    {
        initialOffset = transform.position - targetToFollow.position;
        currentZoomDistance = initialOffset.magnitude;
    }

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
        currentZoomDistance = Mathf.Clamp(currentZoomDistance - zoomAmount, minZoomDistance, maxZoomDistance);

        Vector3 desiredPosition = targetToFollow.position - transform.forward * currentZoomDistance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    public void FocusAndFollow(Transform target)
    {
        targetToFollow = target;
        lastMousePosition = Input.mousePosition;
        initialOffset = transform.position - targetToFollow.position;
        currentZoomDistance = initialOffset.magnitude;
    }

    public void StopFollowing()
    {
        targetToFollow = null;
    }
}
