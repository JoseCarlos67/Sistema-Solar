using UnityEngine;
using UnityEngine.UI;

public class Traslation : MonoBehaviour
{
    public Transform centerObject;
    public float orbitSpeed = 1.0f;
    public Vector3 orbitAxis = Vector3.up; // Eixo de rotação padrão

    // private Vector3 startPosition; Utilizar para resetar o translation
    private float orbitalRadius;
    [SerializeField] public Toggle sel;

    private void Start()
    {
        InitializeOrbit();   
    }

    private void Update()
    {
        if (sel.isOn == true)
        {
            // Atualize o movimento dos planetas apenas se a simula��o n�o estiver pausada.
            if (centerObject != null)
            {
                UpdateOrbit();
            }
        }
    }

    private void InitializeOrbit()
    {
        if(centerObject != null)
        {
            //startPosition = transform.position;
            orbitalRadius = Vector3.Distance(centerObject.position, transform.position);
        }
    }

    public void UpdateOrbit()
    {
        Vector3 offsetFromCenter = transform.position - centerObject.position;
        Quaternion rotation = Quaternion.AngleAxis(orbitSpeed * Time.deltaTime, orbitAxis);
        Vector3 newPosition = centerObject.position + rotation * (offsetFromCenter.normalized * orbitalRadius);
        transform.position = newPosition;
    }

}
