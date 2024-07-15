using UnityEngine;

public class CameraController : MonoBehaviour
{
	// Vari�veis de rota��o
	public float rotationSpeed = 1.0f;

	// Vari�veis de zoom
	public float zoomSpeed = 10.0f;
	public float minZoomDistance = 1.0f;
	public float maxZoomDistance = 20.0f;
	private float currentZoomDistance;

	public GameObject planetFocus;

	// Vari�veis de foco
	public float followSpeed = 10;
	public Transform currentTarget;
	private Transform currentFocus;
	private Vector3 lastMousePosition;
	private Vector3 initialOffset;
	public Traslation planetTraslation;

	public GameObject informationObject;

	public static CameraController instance;

	private CameraRotationController rotationController;

	private void Awake() 
	{
		instance = this;
	}

	private void Start()
	{
		ConfigureCamera();
		currentTarget = GameObject.Find("Sol").transform;
		planetTraslation = currentTarget.GetComponent<Traslation>();
		initialOffset = transform.position - currentTarget.position;
		currentZoomDistance = initialOffset.magnitude;
	}

	private void Update()
	{        
		HandleRotation();
		HandleZoom();
		HandleFocus();

		// Verifica se uma tecla n�merica foi presionada 
		for (int i = 0; i <= 8; i++)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				ChangeFocusByNumber(i);
			}
		}
	}

	private void ConfigureCamera()
	{
		currentTarget = GameObject.Find("Sol").transform;
		planetTraslation = currentTarget.GetComponent <Traslation>();
		initialOffset = transform.position - currentTarget.position;
		currentZoomDistance = initialOffset.magnitude;
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
			transform.RotateAround(currentTarget.position, Vector3.up, delta.x * rotationSpeed * Time.deltaTime);
			transform.RotateAround(currentTarget.position, transform.right, -delta.y * rotationSpeed * Time.deltaTime);
			lastMousePosition = Input.mousePosition;
		}
	}

	private void HandleZoom()
	{
		float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
		currentZoomDistance = Mathf.Clamp(currentZoomDistance - zoomAmount, minZoomDistance, maxZoomDistance);

		Vector3 desiredPosition = currentTarget.position - transform.forward * currentZoomDistance;
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

					// Atualize explicitamente a vari�vel planetTraslation
					planetTraslation = currentTarget.GetComponent<Traslation>();
					if (planetTraslation != null)
					{
						//followSpeed = planetTraslation.orbitSpeed;
						// followSpeed = 0.2f + targetToFollow.GetComponent<Traslation>().orbitSpeed;
						maxZoomDistance = currentTarget.GetComponent<CelestialBody>().MaxZoomDistance;
						minZoomDistance = currentTarget.GetComponent<CelestialBody>().MinZoomDistance;
					}
					else
					{
						Debug.LogError("O planeta n�o tem o componente Traslation.");
					}
				}
			}
		}
	}

	private void CheckNumberKeyInput()
	{
		for(int i = 0; i <= 8; i++)
		{
			if(Input.GetKeyDown(i.ToString()))
			{
				ChangeFocusByNumber(i);
			}
		}
	}

	public void ChangeFocusByNumber(int planetNumber)
	{
		// Define os nomes dos planetas com base nos seus GameObjects
		string[] planetNames = {"Sol", "Mercurio", "Venus", "Terra", "Marte", "Jupiter", "Saturno", "Urano", "Netuno"};

		// Verifica se o n�mero do planeta est� dentro dos limites
		if (planetNumber >= 0 && planetNumber <= planetNames.Length)
		{
			Transform newFocus = GameObject.Find(planetNames[planetNumber]).transform;

			if (newFocus != null)
			{
				SetFocus(newFocus);
			} else
			{
				Debug.LogError("Planeta n�o encontrado com o n�mero: " + planetNumber);
			}
		} else
		{
			Debug.LogError("N�mero de planeta inv�lido: " + planetNumber);
		}
	}

	public void FocusAndFollow(Transform target)
	{
		currentTarget = target;
		rotationController = gameObject.AddComponent<CameraRotationController>();
		initialOffset = transform.position - currentTarget.position;
		currentZoomDistance = initialOffset.magnitude;
	}

	public void StopFollowing()
	{
		currentTarget = null;
	}

	private void SetFocus(Transform newFocus)
	{
		if (newFocus != currentFocus)
		{
			currentFocus = newFocus;
			currentTarget = newFocus;
			rotationController = new CameraRotationController(rotationSpeed, currentTarget);
			InformationControl.instance.informationObject.SetActive(false);
			InformationControl.instance.isShowing = false;
			maxZoomDistance = currentTarget.GetComponent<CelestialBody>().MaxZoomDistance;
			minZoomDistance = currentTarget.GetComponent<CelestialBody>().MinZoomDistance;
		}
	}
}