using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform centerObject; // O objeto em torno do qual o planeta orbita
    public float orbitSpeed = 1.0f; // Velocidade de órbita em unidades por segundo

    // Update is called once per frame
    void Update()
    {
        // Calcula a posição do planeta na órbita
        Vector3 offset = transform.position - centerObject.position;
        Quaternion rotation = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0);
        offset = rotation * offset;
        transform.position = centerObject.position + offset;

        // Mantém a rotação do planeta olhando para o centro do sistema (opcional)
        transform.LookAt(centerObject);
    }
}
