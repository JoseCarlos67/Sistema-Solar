using UnityEngine;

public class CelestialBody : MonoBehaviour
{
	[SerializeField] private float minZoomDistance;
	[SerializeField] private float maxZoomDistance;
	[SerializeField] private float orbitSpeed;
	[SerializeField] private Traslation? celestial;
	public bool isFocus;
	public string nameCelestial;
	
	public float MinZoomDistance { get => minZoomDistance; set => minZoomDistance = value; }
	public float MaxZoomDistance {	get => maxZoomDistance; set => maxZoomDistance = value; }
	public float OrbitSpeed { get => orbitSpeed; set => orbitSpeed = value; }

	public void Awake()
	{
		orbitSpeed = celestial.GetComponent<Traslation>().orbitSpeed;
	}
	
	public void Update()
	{
		IsFocus();
	}
	
	public void IsFocus()
	{
		string nameCelestialFocus = CameraController.instance.currentTarget.name;
		
		if(nameCelestial == nameCelestialFocus)
		{
			isFocus = true;
		} 
		if(nameCelestial != nameCelestialFocus)
		{
			isFocus = false;
		}
	}
}
