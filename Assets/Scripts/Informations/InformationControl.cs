using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationControl : MonoBehaviour
{
	[Header("Components")]
	public GameObject informationObject;
	public TextMeshProUGUI aboutTextField;
	public TextMeshProUGUI celestialNameTextField;
	public TextMeshProUGUI composition;
	public TextMeshProUGUI position;
	public TextMeshProUGUI averageTemperature;
	public TextMeshProUGUI mass;
	public TextMeshProUGUI diameter;
	public TextMeshProUGUI lifePresent;
	public TextMeshProUGUI translationSpeed;
	public TextMeshProUGUI rotationSpeed;
	public TextMeshProUGUI naturalSatellites;
	
	[Header("Settings")]
	public float typingSpeed;
	
	[SerializeField]public bool isShowing;
	public int index;
	
	public string[] informations;
	
	private CelestialInformation celestialInformation;
	
	public static InformationControl instance;
	
	private void Awake()
	{
		instance = this;
	}
	
	IEnumerator TypeInformation()
	{
		foreach(char letter in informations[index].ToCharArray())
		{
			aboutTextField.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
		
	}
		
	public void Speech(string txt, string celestialName, string diameter, string composition, string position, string averageTemperature, string mass, string lifePresent, string translationSpeed, string rotationSpeed, string naturalSatellites)
	{
		if (!isShowing)
		{
			informationObject.SetActive(true);

			//informations = txt;
			celestialNameTextField.text = celestialName;
			this.diameter.text = diameter;
			this.composition.text = composition;
			this.position.text =  position;
			this.averageTemperature.text = averageTemperature;
			this.mass.text = mass;
			this.lifePresent.text = lifePresent;
			this.translationSpeed.text = translationSpeed;
			this.rotationSpeed.text = rotationSpeed;
			this.naturalSatellites.text = naturalSatellites;
			this.aboutTextField.text = txt;
			//StartCoroutine(TypeInformation());
			isShowing = true;
		}
	}
	
	public void NextSentence()
	{
		aboutTextField.text = "";
		index = 0;
		informationObject.SetActive(false);
		informations = null;
		isShowing = false;
	}

    internal void Speech(List<string> informations, string nameCelestial, string diameter, string composition, string position, string averageTemperature, string mass, string lifePresent, string translationSpeed, string rotationSpeed, string naturalSatellitesCount)
    {
        throw new NotImplementedException();
    }
}
