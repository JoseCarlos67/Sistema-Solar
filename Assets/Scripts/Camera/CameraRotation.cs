using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variáveis de rotação
    public float rotationSpeed = 1.0f;

    // Variáveis de zoom
    public float zoomSpeed = 10.0f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 20.0f;
    private float currentZoomDistance;

    private GameObject planetFocus;
    GameController gameController;

    // Variáveis de foco
    public float followSpeed = 0.8f;
    public Transform targetToFollow;
    private Transform currentFocus;
    private Vector3 lastMousePosition;
    private Vector3 initialOffset;
    public Traslation planetTraslation;

    private void Start()
    {
        targetToFollow = GameObject.Find("Sun").transform;
        planetTraslation = targetToFollow.GetComponent<Traslation>();
        initialOffset = transform.position - targetToFollow.position;
        currentZoomDistance = initialOffset.magnitude;
    }

    private void Update()
    {        
        HandleRotation();
        HandleZoom();
        HandleFocus();

        // Verifica se uma tecla númerica foi presionada 
        for (int i = 0; i <= 8; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ChangeFocusByNumber(i);
            }
        }
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.RotateAround(targetToFollow.position, Vector3.up, delta.x * rotationSpeed * Time.deltaTime);
            transform.RotateAround(targetToFollow.position, transform.right, -delta.y * rotationSpeed * Time.deltaTime);
            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleZoom()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance - zoomAmount, minZoomDistance, maxZoomDistance);

        Vector3 desiredPosition = targetToFollow.position - transform.forward * currentZoomDistance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    private void HandleFocus()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Transform hitTransform = hit.transform;

                if (hitTransform.CompareTag("Celestial"))
                {
                    SetFocus(hitTransform);

                    // Atualize explicitamente a variável planetTraslation
                    planetTraslation = targetToFollow.GetComponent<Traslation>();
                    if (planetTraslation != null)
                    {
                        followSpeed = planetTraslation.orbitSpeed;
                    }
                    else
                    {
                        Debug.LogError("O planeta não tem o componente Traslation.");
                    }
                }
            }
        }
    }

    public void ChangeFocusByNumber(int planetNumber)
    {
        // Define os nomes dos planetas com base nos seus GameObjects
        string[] planetNames = {"Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};

        // Verifica se o número do planeta está dentro dos limites
        if (planetNumber >= 0 && planetNumber <= planetNames.Length)
        {
            Transform newFocus = GameObject.Find(planetNames[planetNumber]).transform;

            if (newFocus != null)
            {
                SetFocus(newFocus);
            } else
            {
                Debug.LogError("Planeta não encontrado com o número: " + planetNumber);
            }
        } else
        {
            Debug.LogError("Número de planeta inválido: " + planetNumber);
        }
    }

    public void FocusAndFollow(Transform target)
    {
        targetToFollow = target;
        lastMousePosition = Input.mousePosition;
        initialOffset = transform.position - targetToFollow.position;
        currentZoomDistance = initialOffset.magnitude;
    }

    public void StopFollowing()
    {
        targetToFollow = null;
    }

    private void SetFocus(Transform newFocus)
    {
        if (newFocus != currentFocus)
        {
            currentFocus = newFocus;
            targetToFollow = newFocus;
            
        }
    }
}