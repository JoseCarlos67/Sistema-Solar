using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CelestialInformation : MonoBehaviour
{
	private string nameCelestial;
	private string diameter;
	//private string? composition;
	private string position;
	private string averageTemperature;
	private string mass;
	private string lifePresent;
	private string translationSpeed;
	private string rotationSpeed;
	private string naturalSatellitesCount;

	public bool cameraFocus;
	
	public InformationSettings informationSettings;
	//private List<string> informations = new();
	private string informations;

	
	void Start()
	{
		GetTexts();
	}
	
	void Update()
	{
		ShowInformation();
		if(Input.GetKeyDown(KeyCode.I) && cameraFocus)
		{
			InformationControl.instance.Speech(informations, nameCelestial, diameter, position, averageTemperature, mass, lifePresent, translationSpeed, rotationSpeed, naturalSatellitesCount);
		}
	}
	
	public void GetTexts()
	{
		for(int i = 0; i < informationSettings.informationCelestial.Count; i++)
		{	
			nameCelestial = informationSettings.informationCelestial[i].name;
			informations = informationSettings.informationCelestial[i].about.portuguese;
			diameter = informationSettings.informationCelestial[i].diameter;
			//composition = informationSettings.informationCelestial[i].composition;
			position = informationSettings.informationCelestial[i].position;
			averageTemperature = informationSettings.informationCelestial[i].averageTemperature;
			mass = informationSettings.informationCelestial[i].mass;
			lifePresent = informationSettings.informationCelestial[i].lifePresent;
			translationSpeed = informationSettings.informationCelestial[i].translationSpeed;
			rotationSpeed = informationSettings.informationCelestial[i].rotationSpeed;
			naturalSatellitesCount = informationSettings.informationCelestial[i].naturalSatellitesCount;
		}
	}
	
	public void ShowInformation()
	{
		if(CameraController.instance.currentTarget.gameObject.name == nameCelestial)
		{
			cameraFocus = true;
		} else
		{
			cameraFocus = false;
		}
	}
}
