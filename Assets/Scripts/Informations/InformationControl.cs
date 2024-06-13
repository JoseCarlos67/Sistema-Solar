using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InformationControl : MonoBehaviour
{
	[Header("Components")]
	public GameObject informationObject;
	public Text aboutTextField;
	public Text celestialNameTextField;
	public Text diameter;
	public Text composition;
	public Text position;
	public Text averageTemperature;
	public Text mass;
	public Text lifePresent;
	public Text translationSpeed;
	public Text rotationSpeed;
	public Text naturalSatellites;
	
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
		
	public void Speech(string[] txt, string celestialName, string diameter, string composition, string position, string averageTemperature, string mass, string lifePresent, string translationSpeed, string rotationSpeed, string naturalSatellites)
	{
		if (!isShowing)
		{
			informationObject.SetActive(true);

			informations = txt;
			this.celestialNameTextField.text = celestialName;
			this.diameter.text = diameter;
			this.composition.text = composition;
			this.position.text =  position;
			this.averageTemperature.text = averageTemperature;
			this.mass.text = mass;
			this.lifePresent.text = lifePresent;
			this.translationSpeed.text = translationSpeed;
			this.rotationSpeed.text = rotationSpeed;
			this.naturalSatellites.text = naturalSatellites;

			StartCoroutine(TypeInformation());
			isShowing = true;
		}
	}
	
	public void NextSentence()
	{
		if(aboutTextField.text == informations[index])
		{
			if(index < informations.Length - 1)
			{
				index++;
				aboutTextField.text = "";
				StartCoroutine(TypeInformation());
			} else
			{
				aboutTextField.text = "";
				index = 0;
				informationObject.SetActive(false);
				informations = null;
				isShowing = false;
			}
		}
	}
	
}
