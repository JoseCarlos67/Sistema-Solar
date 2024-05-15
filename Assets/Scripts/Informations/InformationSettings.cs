using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Information", menuName = "New Information")]
public class InformationSettings : ScriptableObject
{
	// [Header("Settings")]
	
	[Header("Information")]
	public string name;
	public string about;
	public string diameter;
	public string composition;
	public int position;
	public float averageTemperature;
	public float mass;
	public string lifePresent;
	public float translationSpeed;
	public float rotationSpeed;
	public int naturalSatellitesCount;
	
	public List<Informations> informationCelestial = new();
}

[System.Serializable]
public class Informations
{
	public string name;
	public Languages about;
	public string diameter;
	public string composition;
	public int position;
	public float averageTemperature;
	public float mass;
	public string lifePresent;
	public float translationSpeed;
	public float rotationSpeed;
	public int naturalSatellitesCount;
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
			language.portuguese = informationSettings.about;
			
			Informations information = new();
			information.name = informationSettings.name;
			information.about = language;
			information.diameter = informationSettings.diameter;
			information.composition = informationSettings.composition;
			information.position = informationSettings.position;
			information.averageTemperature = informationSettings.averageTemperature;
			information.mass = informationSettings.mass;
			information.lifePresent = informationSettings.lifePresent;
			information.translationSpeed = informationSettings.translationSpeed;
			information.rotationSpeed = informationSettings.rotationSpeed;
			information.naturalSatellitesCount = informationSettings.naturalSatellitesCount;
			
			if(GUILayout.Button("Create informatio"))
			{
				if(informationSettings.about != "")
				{
					informationSettings.informationCelestial.Add(information);
					
					informationSettings.name = "";
					informationSettings.about = "";
					informationSettings.diameter = "";
					informationSettings.composition = "";
					informationSettings.position = 0;
					informationSettings.averageTemperature = 0;
					informationSettings.mass = 0;
					informationSettings.lifePresent = "";informationSettings.translationSpeed = 0;
					informationSettings.rotationSpeed = 0;
					informationSettings.naturalSatellitesCount = 0;
				}
			}
		}
	}
#endif