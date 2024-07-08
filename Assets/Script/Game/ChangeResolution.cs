using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Game
{
    public class ChangeResolution : MonoBehaviour
    {
        public Dropdown resolutionDropdown;
        public Toggle fullscreenToggle;
        public Toggle windowedToggle;

        void Start()
        {
            // Remplir le dropdown avec les options de résolution disponibles
            resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();

            foreach (Resolution res in Screen.resolutions)
            {
                options.Add(res.width + "x" + res.height);
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(); });

            // Initialiser le dropdown avec la résolution actuelle
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                if (Screen.resolutions[i].width == Screen.currentResolution.width &&
                    Screen.resolutions[i].height == Screen.currentResolution.height)
                {
                    resolutionDropdown.value = i;
                    break;
                }
            }

            // Initialiser le toggle avec le mode actuel (plein écran ou fenêtré)
            fullscreenToggle.isOn = Screen.fullScreen;
            fullscreenToggle.onValueChanged.AddListener(delegate { SetFullScreen(fullscreenToggle.isOn); });
            windowedToggle.isOn = !Screen.fullScreen;
            windowedToggle.onValueChanged.AddListener(delegate { SetWindowedMode(windowedToggle.isOn); });
        }

        public void SetResolution()
        {
            int index = resolutionDropdown.value;
            Resolution selectedResolution = Screen.resolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
            // Réappliquer la résolution actuelle pour que le changement de mode prenne effet immédiatement
            int index = resolutionDropdown.value;
            Resolution selectedResolution = Screen.resolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullScreen);
        }
        
        public void SetWindowedMode(bool isWindowed)
        {
            Screen.fullScreen = !isWindowed;
            // Réappliquer la résolution actuelle pour que le changement de mode prenne effet immédiatement
            int index = resolutionDropdown.value;
            Resolution selectedResolution = Screen.resolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, !isWindowed);
        }
        
    }
}
