using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Information", menuName = "New Information/Information")]
public class InformationSettings : ScriptableObject
{
	[Header("Informations")]
	public string nameAstro;
	public string about;
	public List<Informations> information = new();
	
}

[System.Serializable]
public class Informations
{
	public string nameAstro;
	public Languages about;
}

[System.Serializable]
public class Languages
{
	public string portuguese;
	public string english;
}

#if UNITY_EDITOR
	[CustomEditor(typeof(InformationSettings))]
	public class BuilderEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			
			InformationSettings informationSetting = (InformationSettings)target;
			
			Languages language = new Languages();
			language.portuguese = informationSetting.about;
			
			Informations information = new Informations();
			information.nameAstro = informationSetting.nameAstro;
			information.about = language;
			
			if(GUILayout.Button("Create Information"))
			{	
				if(informationSetting.about != "")
				{
					informationSetting.information.Add(information);
					informationSetting.nameAstro = "";
					informationSetting.about = "";
				}
			}
		}

	}
#endif
