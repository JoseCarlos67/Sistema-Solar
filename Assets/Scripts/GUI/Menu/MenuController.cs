using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject menuVideo;
    [SerializeField] private bool _optionsActivated = false;

    public TMP_Dropdown resolution;
    public Toggle vSinc;
    public Toggle windowMode;

    void Start()
    {
        ApplyConfigs();
    }

    void Update()
    {
        OpenAndCloseMenu();
    }

    public void OpenAndCloseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_optionsActivated == false)
            {
                menuOptions.SetActive(true);
                _optionsActivated = true;
            }
            else
            {
                menuOptions.SetActive(false);
                _optionsActivated = false;
            }
        }
    }

    public void Controls()
    {

    }

    public void VideoOptions()
    {
        //LoadConfigs();
        menuOptions.SetActive(false);
        menuVideo.SetActive(true);
    }

    public void Save()
    {
        SaveConfigs();
        ReturnToMenuOptions();
    }

    public void ReturnToMenuOptions()
    {
        menuOptions.SetActive(true);
        menuVideo.SetActive(false);
    }

    public void ExitSimulation()
    {
        Application.Quit();
    }

    private void ApplyConfigs()
    {
        var configs = LoadConfigs();

        if (configs == null)
        {
            return;
        }
        Screen.SetResolution(configs.Resolution.width, configs.Resolution.height, !configs.WindowMode);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = configs.Vsinc ? 1 : 0;
    }

    public ConfigModel LoadConfigs()
    {
        try
        {
            var fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SistemaSolar/ConfigData.save";
            if (!File.Exists(fileDirectory))
            {
                return null;
            }
            var binaryFormatter = new BinaryFormatter();
            var file = File.OpenRead(fileDirectory);
            var configs = (ConfigModel)binaryFormatter.Deserialize(file);
            file.Close();

            if (configs != null)
            {
                var option = resolution.options.Where(x => x.text == $"{configs.Resolution.width}x{configs.Resolution.height}").FirstOrDefault();
                resolution.value = resolution.options.IndexOf(option);
                windowMode.isOn = configs.WindowMode;
                vSinc.isOn = configs.Vsinc;
            }
            return configs;

        }
        catch (Exception e)
        {
            return null;
        }
    }

    public void SaveConfigs()
    {
        try
        {

            var resolutionModel = new Resolution();
            switch (resolution.value)
            {
                case 0:
                    resolutionModel.width = 800;
                    resolutionModel.height = 600;
                    break;
                case 1:
                    resolutionModel.width = 1280;
                    resolutionModel.height = 720;
                    break;

                case 2:
                    resolutionModel.width = 1920;
                    resolutionModel.height = 1080;
                    break;

                case 3:
                    resolutionModel.width = 2560;
                    resolutionModel.height = 1440;
                    break;

                case 4:
                    resolutionModel.width = 3840;
                    resolutionModel.height = 2160;
                    break;
            }

            var configs = new ConfigModel()
            {
                Vsinc = vSinc.isOn,
                WindowMode = windowMode.isOn,
                Resolution = resolutionModel
            };

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SistemaSolar/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var binaryFormatter = new BinaryFormatter();
            var file = File.Create(path + "ConfigData.save");
            binaryFormatter.Serialize(file, configs);
            file.Close();
            ApplyConfigs();
        }
        catch (Exception e)
        {
            return;
        }
    }
}
