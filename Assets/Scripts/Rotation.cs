using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 70.0f;
    public bool rotationOn = true;
    public Transform planet;
    public Vector3 customRotationAxis = Vector3.up;



    private void Update()
    {
        if(rotationOn == true)
        {
            UpdateRotation();
        } else
        {
            planet = GetComponent<Traslation>().centerObject.transform;
            transform.LookAt(planet);
        }
        
    }

    private void UpdateRotation()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(customRotationAxis, rotationSpeed * Time.deltaTime);
    }
}
