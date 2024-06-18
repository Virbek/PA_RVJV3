using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonterDeNiveau : MonoBehaviour
{
    [SerializeField] private GameObject affichageHdv;
    private Camera _mainCamera;
    [SerializeField] private LayerMask hdv;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(!IsPointerOverUIElement())
            {
                affichageHdv.SetActive(false);
            }
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;
            Ray ray = _mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,hdv) )
            {
                affichageHdv.SetActive(true);
                
            }
        }
    }


    public void Monter()
    {
        if (NumberRessources.charbon >= 100)
        {
            GameStat.NiveauHdv += 1;
            NumberRessources.charbon -= 100;
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
