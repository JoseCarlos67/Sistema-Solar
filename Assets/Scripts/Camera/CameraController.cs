using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// Variáveis de zoom
	public float zoomSpeed = 10.0f;
	public float minZoomDistance = 1.0f;
	public float maxZoomDistance = 20.0f;
	private float currentZoomDistance;

	public GameObject planetFocus;

	// Variáveis de foco
	public float followSpeed = 10;
	public Transform currentTarget;
	private Transform currentFocus;
	public String nameCurrentFocus;
	private Vector3 initialOffset;
	public Traslation planetTraslation;

	public GameObject informationObject;

	public static CameraController instance;

	private CameraRotationController rotationController;
	private CameraZoomController cameraZoomController;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		ConfigureCamera();
		rotationController = new CameraRotationController(currentTarget);
		cameraZoomController = new CameraZoomController(currentTarget, zoomSpeed, minZoomDistance, maxZoomDistance, followSpeed);
	}

	private void Update()
	{
		rotationController.Rotate();
		cameraZoomController.ZoomController();
		HandleFocus();
		CheckNumberKeyInput();
	}

	private void ConfigureCamera()
	{
		currentTarget = GameObject.Find("Sistema Solar").transform;
		maxZoomDistance = currentTarget.GetComponent<CelestialBody>().MaxZoomDistance;
		minZoomDistance = currentTarget.GetComponent<CelestialBody>().MinZoomDistance;
		planetTraslation = currentTarget.GetComponent<Traslation>();
		initialOffset = transform.position - currentTarget.position;
		currentZoomDistance = initialOffset.magnitude;
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
					planetTraslation = currentTarget.GetComponent<Traslation>();
					if (planetTraslation != null)
					{
						maxZoomDistance = currentTarget.GetComponent<CelestialBody>().MaxZoomDistance;
						minZoomDistance = currentTarget.GetComponent<CelestialBody>().MinZoomDistance;
					}
					else
					{
						Debug.LogError("O planeta não tem o componente Traslation.");
					}
				}
			}
		}
	}

	private void CheckNumberKeyInput()
	{
		for (int i = 0; i <= 9; i++)
		{
			if (Input.GetKeyDown(i.ToString()))
			{
				ChangeFocusByNumber(i);
			}
		}
	}

	public void ChangeFocusByNumber(int planetNumber)
	{
		// Define os nomes dos planetas com base nos seus GameObjects
		string[] planetNames = { "Sol", "Mercurio", "Venus", "Terra", "Marte", "Júpiter", "Saturno", "Urano", "Netuno", "Sistema Solar" };

		// Verifica se o número do planeta está dentro dos limites
		if (planetNumber >= 0 && planetNumber < planetNames.Length)
		{
			Transform newFocus = GameObject.Find(planetNames[planetNumber]).transform;

			if (newFocus != null)
			{
				SetFocus(newFocus);
			}
			else
			{
				Debug.LogError("Planeta não encontrado com o número: " + planetNumber);
			}
		}
		else
		{
			Debug.LogError("Número de planeta inválido: " + planetNumber);
		}
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
			nameCurrentFocus = currentFocus.name; 
			currentTarget = newFocus;
			rotationController = new CameraRotationController(currentTarget);
			cameraZoomController = new CameraZoomController(currentTarget, zoomSpeed, minZoomDistance, maxZoomDistance, followSpeed);
			InformationControl.instance.informationObject.SetActive(false);
			InformationControl.instance.isShowing = false;
			maxZoomDistance = currentTarget.GetComponent<CelestialBody>().MaxZoomDistance;
			minZoomDistance = currentTarget.GetComponent<CelestialBody>().MinZoomDistance;
		}
	}
}
