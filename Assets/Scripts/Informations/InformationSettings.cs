using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Information", menuName = "New Information")]
public class InformationSettings : ScriptableObject
{
	// [Header("Settings")]
	
	[Header("Information")]
	public string nameCelestial;
	public string aboutCelestial;
	public List<Informations> informationCelestial = new();
}

[System.Serializable]
public class Informations
{
	public string name;
	public Languages about;
}

[System.Serializable]
public class Languages
{
	public string portuguese; // Brazil
	public string english;
	public string spanish;
}

#if UNITY_EDITOR
	[CustomEditor(typeof(InformationSettings))]
	public class BuilderEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			
			InformationSettings informationSettings = (InformationSettings)target;
	
			Languages language = new();
			language.portuguese = informationSettings.aboutCelestial;
			
			Informations information = new();
			information.name = informationSettings.nameCelestial;
			information.about = language;
			
			if(GUILayout.Button("Create informatio"))
			{
				if(informationSettings.aboutCelestial != "")
				{
					informationSettings.informationCelestial.Add(information);
					
					informationSettings.nameCelestial = "";
					informationSettings.aboutCelestial = "";
				}
			}
		}
	}
#endif