using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // O eixo de rotação desejado
    public float rotationSpeed = 70.0f;

    private Transform planetAxis; // Referência ao objeto do cilindro representando o eixo

    private void Start()
    {
        // Encontre o objeto do cilindro (o eixo) como um filho deste planeta
        planetAxis = transform.Find("Axis"); // Altere "Axis" para o nome real do objeto do cilindro.

        if (planetAxis == null)
        {
            Debug.LogError("Axis object not found. Make sure the cylinder is a child of the planet.");
        }
    }

    private void FixedUpdate()
    {
        // Gire o planeta em torno do eixo desejado
        transform.Rotate(rotationAxis, rotationSpeed * Time.fixedDeltaTime);
    }
}
