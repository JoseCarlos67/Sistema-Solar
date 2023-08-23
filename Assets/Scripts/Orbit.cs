using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform centerObject;
    public float orbitSpeed = 1.0f;
    public float speed = 70.0f;

    private Vector3 startPosition;
    private Vector3 axisOfRotation;
    private float orbitalRadius;

    // Start is called before the first frame update
    void Start()
    {
        if (centerObject != null)
        {
            startPosition = transform.position;
            orbitalRadius = Vector3.Distance(centerObject.position, transform.position);
            axisOfRotation = Vector3.up;
        }
        else
        {
            Debug.LogError("Center object is not assigned to " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (centerObject != null)
        {
            // Mantém o raio orbital constante
            Vector3 desiredPosition = centerObject.position + Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0) * (transform.position - centerObject.position).normalized * orbitalRadius;
            transform.position = desiredPosition;

            // Mantém a rotação do objeto virada para o centro
           // transform.LookAt(centerObject);
        }

        this.transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}