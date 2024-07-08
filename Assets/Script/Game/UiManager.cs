using System.Collections.Generic;
using Script.Game.System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Game
{
    public class UiManager : MonoBehaviour
    {

        [SerializeField] private GameObject uiCampagne;
        [SerializeField] private GameObject uiConstruction;

        [SerializeField] private Text unit;
        [SerializeField] private Text numberCamp;
        [SerializeField] private Text nivHdv;
        [SerializeField] private Text numberCollecteur;
        [SerializeField] private Text maxCollecteur;
        [SerializeField] private GameObject Escape;
        private bool visible;
        

        [SerializeField] private GameObject Niveau2;
        // Start is called before the first frame update

        private void Start()
        {
            visible = false;
        }

        public void UiCampagne()
        {
            uiCampagne.SetActive(true);
            if (GameStat.Niveau < 2 )
            {
                Niveau2.SetActive(false);
            }
            else
            {
                Niveau2.SetActive(true);
            }
        }
    
        public void UiConstruction()
        {
            uiConstruction.SetActive(true);
        }

        private void Update()
        {
            Escape.SetActive(visible);
            var nombreUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon + NumberUnit.ballonDef;
            unit.text = nombreUnit.ToString();
            numberCamp.text = " / "+NumberUnit.numberUnitInCamp.ToString();
            nivHdv.text = GameStat.NiveauHdv.ToString();

            numberCollecteur.text = GameStat.collecteur.ToString();
            maxCollecteur.text = "/ " + GameStat.maxCollecteur.ToString();
                

            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIElement())
                {
                    uiCampagne.SetActive(false);
                    uiConstruction.SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                visible = !visible;
            }
        }
    
        private bool IsPointerOverUIElement()
        {
            // Crée une liste pour stocker les résultats du raycast
            List<RaycastResult> eventSystemRaycastResults = GetEventSystemRaycastResults();
            return eventSystemRaycastResults.Count > 0;
        }

        // Utilise EventSystem pour faire un raycast et obtenir tous les résultats
        private List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results;
        }

        public void Reprendre()
        {
            visible = !visible;
        }

        public void Quitter()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
