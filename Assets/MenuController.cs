using System.Collections.Generic;
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
        PopulateResolutionDropdown();
        applyButton.onClick.AddListener(ApplySettings);
    }

    public void Option()
    {
        Debug.Log("Option button clicked");
        if (menu != null && optionsPanel != null)
        {
            menu.SetActive(false);
            optionsPanel.SetActive(true);
            Debug.Log("Menu deactivated and Options panel activated");
        }
        else
        {
            Debug.LogWarning("Menu or OptionsPanel not assigned in the inspector");
        }
    }

    public void ChangeScene()
    {
        Debug.Log("Change scene to SampleScene");
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("Quit application");
        Application.Quit();
    }

    public GameObject Panel;
    bool visible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
            Debug.Log("Panel visibility toggled to " + visible);
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

        Debug.Log("Applying settings: " + selectedResolution.width + " x " + selectedResolution.height + ", Fullscreen: " + isFullscreen);

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullscreen, selectedResolution.refreshRate);

        Debug.Log("Settings applied: " + Screen.currentResolution.width + " x " + Screen.currentResolution.height + ", Fullscreen: " + Screen.fullScreen);
    }
}
