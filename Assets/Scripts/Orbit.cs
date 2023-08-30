using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform centerObject;
    public float orbitSpeed = 1.0f;
    public float rotationSpeed = 70.0f;
    private Vector3 startPosition;
    private float orbitalRadius;

    private void Start()
    {
        InitializeOrbit();
    }

    private void Update()
    {
        if (centerObject != null)
        {
            UpdateOrbit();
            UpdateRotation();
        }
        else
        {
            Debug.LogError("Center object is not assigned to " + gameObject.name);
        }
    }

    private void InitializeOrbit()
    {
        if (centerObject != null)
        {
            startPosition = transform.position;
            orbitalRadius = Vector3.Distance(centerObject.position, transform.position);
        }
    }

    private void UpdateOrbit()
    {
        Vector3 offsetFromCenter = transform.position - centerObject.position;
        Quaternion rotation = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0);
        Vector3 newPosition = centerObject.position + rotation * (offsetFromCenter.normalized * orbitalRadius);
        transform.position = newPosition;
    }

    private void UpdateRotation()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}