using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CasernManager : MonoBehaviour
{
    [SerializeField] private GameObject selectionUnit;
    [SerializeField] private GameObject Geant;
    private Camera _mainCamera;
    private List<GameObject> _unit;
    private float timeToSpawn = 0;
    private List<GameObject> unit = new List<GameObject>();
    [SerializeField]private int nombreUnitInCamp;
    [SerializeField] private LayerMask caserne;
    [SerializeField] private LayerMask ui;
    [SerializeField]private BoxCollider camp;
    private int nombreGold;

    void Start()
    {
        _mainCamera = Camera.main;
        nombreUnitInCamp = 0;
    }

 
    void Update()
    {
        nombreGold = NumberRessources.gold;
        if (Input.GetMouseButton(0))
        {
            if(!IsPointerOverUIElement())
            {
                selectionUnit.SetActive(false);
            }
            RaycastHit hit;
            Vector3 mousePos = Input.mousePosition;
            Ray ray = _mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,caserne) )
            {
                selectionUnit.SetActive(true);
                if (GameStat.NiveauHdv > 1)
                {
                    Geant.SetActive(true);
                }
                else
                {
                    Geant.SetActive(false);
                }
                
            }
        }

        if (unit.Count>0)
        {
            timeToSpawn += Time.deltaTime;
            if (timeToSpawn >= 1.0f )
            {
                SpawnerUnit(unit[0]);
                unit.Remove(unit[0]);
                timeToSpawn = 0;
            }
        }
    }

    public void CreateWarrior(GameObject war)
    {
        if (nombreGold >= 50)
        {
            if (nombreUnitInCamp <= 50)
            {
                unit.Add(war);
                NumberUnit.guerrier += 1;
                nombreUnitInCamp += 1;
                NumberRessources.gold -= 50;
            }
        }
        
        
    }
    
    public void CreateArrow(GameObject arr)
    {
        if (nombreGold >= 50)
        {
            if (nombreUnitInCamp <= 50)
            {
                unit.Add(arr);
                NumberUnit.archer += 1;
                nombreUnitInCamp += 1;
                NumberRessources.gold -= 50;
            }
        }
        
    }
    
    public void CreateGeant(GameObject gea)
    {
        if (nombreGold >= 100)
        {
            if (nombreUnitInCamp <= 50)
            {
                unit.Add(gea);
                NumberUnit.geant += 1;
                nombreUnitInCamp += 1;
                NumberRessources.gold -= 100;
            }
        }
        
    }

    private void SpawnerUnit(GameObject u)
    {
       
        var newWar = Instantiate(u, transform.position, Quaternion.identity);
        newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
        
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
