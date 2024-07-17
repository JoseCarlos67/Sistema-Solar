using System;
using UnityEngine;

public class CameraZoomController
{
    private float zoomSpeed;
    private float minZoomDistance;
    private float maxZoomDistance;
    private float currentZoomDistance;
    private float followSpeed;
    private Transform currentTarget;

    public CameraZoomController(Transform target, float zoomSpeed, float minZoomDistance, float maxZoomDistance, float followSpeed)
    {
        this.zoomSpeed = zoomSpeed;
        this.minZoomDistance = minZoomDistance;
        this.maxZoomDistance = maxZoomDistance;
        this.followSpeed = followSpeed;
        currentTarget = target;
        currentZoomDistance = Vector3.Distance(Camera.main.transform.position, currentTarget.position);
        Debug.Log("Initial Zoom Distance: " + currentZoomDistance);
    }

    public void ZoomController()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance - zoomAmount, CameraController.instance.minZoomDistance, CameraController.instance.maxZoomDistance);
        Debug.Log("Zoom Amount: " + zoomAmount);
        Debug.Log("Current Zoom Distance: " + currentZoomDistance);

        Vector3 desiredPosition = currentTarget.position - Camera.main.transform.forward * currentZoomDistance;
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, followSpeed * Time.deltaTime);
        Camera.main.transform.position = smoothedPosition;

        Debug.Log("Camera Position: " + Camera.main.transform.position);
    }
}
