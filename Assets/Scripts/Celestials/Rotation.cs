using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // O eixo de rota��o desejado
    public float rotationSpeed = 70.0f;

    [SerializeField] private Toggle sel;

    private Transform planetAxis; // Refer�ncia ao objeto do cilindro representando o eixo

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
        if (sel.isOn == true)
        {
            // Gire o planeta em torno do eixo desejado
            transform.Rotate(rotationAxis, rotationSpeed * Time.fixedDeltaTime);
        }
      
    }

}
