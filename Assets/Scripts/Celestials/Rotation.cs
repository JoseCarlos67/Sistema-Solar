using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // O eixo de rota��o desejado
    public float rotationSpeed = 70.0f;

    [SerializeField] private Toggle sel;

    private void FixedUpdate()
    {
        if (sel.isOn == true)
        {
            // Gira o planeta em torno do eixo desejado
            transform.Rotate(rotationAxis, rotationSpeed * Time.fixedDeltaTime);
        }
    }

}
