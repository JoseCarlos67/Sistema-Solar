using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InformationControl : MonoBehaviour
{
	[Header("Components")]
	public GameObject informationObject;
	public Text aboutTextField;
	public Text celestialNameTextField;
	
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
		
	public void Speech(string[] txt)
	{
		if(!isShowing)
		{
			informationObject.SetActive(true);
			informations = txt;
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
