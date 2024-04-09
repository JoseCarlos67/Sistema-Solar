using UnityEngine;
using UnityEngine.UI;

public class CelestialInformation : MonoBehaviour
{
	public bool cameraFocus;
	public InformationSettings information;
	[SerializeField] private string aboutText;
	[SerializeField] private string nameAstro;
	[SerializeField] private Toggle toggleSelected;

	private void Start() 
	{
		GetTexts();
	}

	void Update()
	{
		ShowInformations();
		if(toggleSelected.isOn == true && cameraFocus) 
		{
			InformationControl.instanceInformacionControl.ShowInformationInPanel(aboutText.ToString(), nameAstro);
			Debug.Log("Cheguei aqui");
		} else 
		{
			InformationControl.instanceInformacionControl.informationObj.SetActive(false);
		}
	}
	
	void GetTexts() 
	{	
		nameAstro = information.information[0].nameAstro;
		for(int i = 0; i < information.information.Count; i++) 
		{
			aboutText = information.information[i].about.portuguese;
			nameAstro = information.information[i].nameAstro;
		}
	}
	
	public void ShowInformations() 
	{
		if (CameraController.instanceCameraController.targetToFollow.gameObject.name == nameAstro) 
		{
			cameraFocus = true;
		} else 
		{
			cameraFocus = false;
			InformationControl.instanceInformacionControl.informationObj.SetActive(false);
		}
	}
}
