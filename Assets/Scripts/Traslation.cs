using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traslation : MonoBehaviour
{
    public Transform centerObject;
    public float orbitSpeed = 1.0f;

    private Vector3 startPosition;
    private float orbitalRadius;
    private bool isPaused = false;

    private void Start()
    {
        InitializeOrbit();   
    }
    private void Update()
    {
        if (!isPaused)
        {
            // Atualize o movimento dos planetas apenas se a simulação não estiver pausada.
            if (centerObject != null)
            {
                UpdateOrbit();
            }
            else
            {
                Debug.LogError("Center object is not assigned to " + gameObject.name);
            }
        }
    }

    private void InitializeOrbit()
    {
        if(centerObject != null)
        {
            startPosition = transform.position;
            orbitalRadius = Vector3.Distance(centerObject.position, transform.position);
        }
    }

    public void UpdateOrbit()
    {
        
            Vector3 offsetFromCenter = transform.position - centerObject.position;
            Quaternion rotation = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0);
            Vector3 newPosition = centerObject.position + rotation * (offsetFromCenter.normalized * orbitalRadius);
            transform.position = newPosition;
    }

    public void PauseSimulation()
    {
        isPaused = true;
    }

    public void ResumeSimulation()
    {
        isPaused = false;
    }

}
