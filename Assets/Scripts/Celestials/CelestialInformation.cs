using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CelestialInformation : MonoBehaviour
{
	public string nameCelestial;
	public bool cameraFocus;
	
	public InformationSettings informationSettings;
	private List<string> informations = new();
	public Toggle toggleSelected;
	
	void Start()
	{
		GetTexts();
	}
	
	void Update()
	{
		ShowInformation();
		if(Input.GetKeyDown(KeyCode.I) && cameraFocus)
		{
			InformationControl.instance.Speech(informations.ToArray());
		}
	}
	
	public void GetTexts()
	{
		for(int i = 0; i < informationSettings.informationCelestial.Count; i++)
		{
			informations.Add(informationSettings.informationCelestial[i].about.portuguese);
		}
	}
	
	public void ShowInformation()
	{
		if(CameraController.instance.targetToFollow.gameObject.name == nameCelestial)
		{
			cameraFocus = true;
		} else
		{
			cameraFocus = false;
		}
	}
}
