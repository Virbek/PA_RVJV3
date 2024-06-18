using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Game
{
    public class UiManager : MonoBehaviour
    {

        [SerializeField] private GameObject uiCampagne;
        [SerializeField] private GameObject uiConstruction;

        [SerializeField] private Text unit;
        [SerializeField] private Text nivHdv;

        [SerializeField] private GameObject Niveau2;
        // Start is called before the first frame update

        private void Start()
        {
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
            var nombreUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant;
            unit.text = nombreUnit.ToString();
            nivHdv.text = GameStat.NiveauHdv.ToString();

            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIElement())
                {
                    uiCampagne.SetActive(false);
                    uiConstruction.SetActive(false);
                }
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
    }
}
