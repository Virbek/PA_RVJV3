using System.Collections.Generic;
using Script.Component;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Button applyButton;

    private List<Resolution> resolutions;

    void Start()
    {
        World.DefaultGameObjectInjectionWorld.EntityManager.CreateSingleton<WantToSpawn>();
        PopulateResolutionDropdown();
        applyButton.onClick.AddListener(ApplySettings);
    }

    public void Option()
    {
        if (menu != null && optionsPanel != null)
        {
            menu.SetActive(false);
            optionsPanel.SetActive(true);
        }
        else
        {
        }
    }

    public void jouer()
    {
        GameStat.collecteur += 1;
        GameStat.positionColl[0] = new float3(0.05f, 0.07f, 0.47f);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public GameObject Panel;
    bool visible = false;

    void Update()
    {
        GameStat.collecteur = 0;
        GameStat.NiveauHdv = 1;
        GameStat.Niveau = 1;
        NumberRessources.gold = 0;
        NumberRessources.charbon = 0;
        NumberUnit.guerrier = 0;
        NumberUnit.archer = 0;
        NumberUnit.geant = 0;
        NumberUnit.bat = 0;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
        }
    }

    void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        resolutions = new List<Resolution>(Screen.resolutions);
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ApplySettings()
    {
        int selectedResolutionIndex = resolutionDropdown.value;
        Resolution selectedResolution = resolutions[selectedResolutionIndex];
        bool isFullscreen = fullscreenToggle.isOn;

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullscreen,
            selectedResolution.refreshRate);
    }
}
