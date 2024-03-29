using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class CelestialBody : MonoBehaviour
{
	[SerializeField] private float minZoomDistance;
	[SerializeField] private float maxZoomDistance;
	[SerializeField] private float orbitSpeed;
	[SerializeField] private Traslation celestial;

	public float MinZoomDistance { get => minZoomDistance; set => minZoomDistance = value; }
	public float MaxZoomDistance {	get => maxZoomDistance; set => maxZoomDistance = value; }

	public void Awake()
	{
		orbitSpeed = celestial.GetComponent<Traslation>().orbitSpeed;
	}
	
}
