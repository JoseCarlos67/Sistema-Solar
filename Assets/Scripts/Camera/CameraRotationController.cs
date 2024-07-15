using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    private float rotationSpeed;
    public Transform targetToFollow;
    public Vector3 lastMousePosition;

    public CameraRotationController(float rotationSpeed,Transform targetToFollow)
    {
        this.rotationSpeed = rotationSpeed;
        this.targetToFollow = targetToFollow;
    }

    public void Rotate() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if(Input.GetMouseButton(0)){
            Vector3 delta = Input.mousePosition - lastMousePosition;
            RotateAroundTarget(delta);
            lastMousePosition = Input.mousePosition;
        }
    }

    private void RotateAroundTarget(Vector3 delta)
    {
        float deltaX = delta.x * rotationSpeed * Time.deltaTime;
        float deltaY = delta.y * rotationSpeed * Time.deltaTime;

        Camera.main.transform.RotateAround(targetToFollow.position, Vector3.up, deltaX);
        Camera.main.transform.RotateAround(targetToFollow.position, Camera.main.transform.right, deltaY);
    }

}
