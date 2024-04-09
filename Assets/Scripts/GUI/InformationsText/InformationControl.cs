using UnityEngine;
using UnityEngine.UI;

public class InformationControl : MonoBehaviour
{
	[Header("Components")]
	public GameObject informationObj; // Janela das informacoes
	public Text aboutTextField;
	public Text astroNameTextField;
	
	private bool isShowing;
	private string about;
	private string astroName;
	
	public static InformationControl instanceInformacionControl;
	
	public void Awake() 
	{
		instanceInformacionControl = this;
	}
	
	public void TypeInformation() 
	{
		aboutTextField.text = about;
		astroNameTextField.text = astroName;
	}
	
	public void ShowInformationInPanel(string about, string astroName) 
	{
		if(!isShowing) 
		{
			informationObj.SetActive(true);
			this.about = about;
			this.astroName = astroName;
			TypeInformation();
		}
	}

	// public void NextAboutInformation() 
	// {
		
	// }
}
