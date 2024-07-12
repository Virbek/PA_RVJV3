using System.Collections;
using System.Collections.Generic;
using Script.Game;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CasernManager : MonoBehaviour
{
    [SerializeField] private GameObject selectionUnit;
    [SerializeField] private GameObject Geant;
    [SerializeField] private GameObject Ballon;
    [SerializeField] private GameObject BallonDef;
    
    [SerializeField] private GameObject prefabGuerrier;
    [SerializeField] private GameObject prefabArcher;
    [SerializeField] private GameObject prefabGeant;
    [SerializeField] private GameObject prefabBallon;
    [SerializeField] private GameObject prefabBallonDef;
    
    private Camera _mainCamera;
    private List<GameObject> _unit;
    private float timeToSpawn = 0;
    private List<GameObject> unit = new List<GameObject>();
    [SerializeField]private int nombreUnitInCamp;
    private int numberUnit;
    [SerializeField] private LayerMask caserne;
    [SerializeField] private LayerMask ui;
    [SerializeField]private BoxCollider camp;
    private int nombreGold;
    private int countUnit;

    void Start()
    {
        _mainCamera = Camera.main;
    }

 
    void Update()
    {
        if (NumberUnit.unitToSpawn == 0)
        {
            countUnit = 0;
        }
        RespawnUnit();
        numberUnit = NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon + NumberUnit.ballonDef;
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
                if(GameStat.NiveauHdv > 2)
                {
                    Ballon.SetActive(true);
                }
                else
                {
                    Ballon.SetActive(false);
                }
                if(GameStat.NiveauHdv > 3)
                {
                    BallonDef.SetActive(true);
                }
                else
                {
                    BallonDef.SetActive(false);
                }
                
            }
        }

        if (unit.Count>0)
        {
            timeToSpawn += Time.deltaTime;
            if (timeToSpawn >= 0.1f )
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
            if (numberUnit  <= NumberUnit.numberUnitInCamp)
            {
                unit.Add(war);
                NumberUnit.guerrier += 1;
                NumberRessources.gold -= 50;
            }
        }
        
        
    }
    
    public void CreateArrow(GameObject arr)
    {
        if (nombreGold >= 50)
        {
            if (numberUnit <= NumberUnit.numberUnitInCamp)
            {
                unit.Add(arr);
                NumberUnit.archer += 1;
                NumberRessources.gold -= 50;
            }
        }
        
    }
    
    public void CreateGeant(GameObject gea)
    {
        if (nombreGold >= 100)
        {
            if (numberUnit <= NumberUnit.numberUnitInCamp)
            {
                unit.Add(gea);
                NumberUnit.geant += 1;
                NumberRessources.gold -= 100;
            }
        }
        
    }
    
    public void CreateBallon(GameObject ball)
    {
        if (nombreGold >= 75)
        {
            if (numberUnit <= NumberUnit.numberUnitInCamp)
            {
                unit.Add(ball);
                NumberUnit.ballon += 1;
                NumberRessources.gold -= 75;
            }
        }
        
    }
    
    public void CreateBallonDef(GameObject ball)
    {
        if (nombreGold >= 150)
        {
            if (numberUnit <= NumberUnit.numberUnitInCamp)
            {
                unit.Add(ball);
                NumberUnit.ballonDef += 1;
                NumberRessources.gold -= 150;
            }
        }
        
    }

    private void SpawnerUnit(GameObject u)
    {
       
        var newWar = Instantiate(u, transform.position, Quaternion.identity);
        newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
        newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
        
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

    private void RespawnUnit()
    {
        Debug.Log(NumberUnit.unitToSpawn);
        Debug.Log(NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon+ NumberUnit.ballonDef);
        if (NumberUnit.unitToSpawn > 0)
        {
            if (countUnit < NumberUnit.guerrier)
            {
                var newWar = Instantiate(prefabGuerrier, transform.position, Quaternion.identity);
                newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
                newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
                countUnit += 1;
                NumberUnit.unitToSpawn -= 1;
            }else if (countUnit < NumberUnit.guerrier + NumberUnit.archer)
            {
                var newWar = Instantiate(prefabArcher, transform.position, Quaternion.identity);
                newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
                newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
                countUnit += 1;
                NumberUnit.unitToSpawn -= 1;
                
            }else if (countUnit < NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant)
            {
                var newWar = Instantiate(prefabGeant, transform.position, Quaternion.identity);
                newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
                newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
                countUnit += 1;
                NumberUnit.unitToSpawn -= 1;
                
            }else if (countUnit < NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon)
            {
                var newWar = Instantiate(prefabBallon, transform.position, Quaternion.identity);
                newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
                newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
                countUnit += 1;
                NumberUnit.unitToSpawn -= 1;
                
            }
            else if (countUnit < NumberUnit.guerrier + NumberUnit.archer + NumberUnit.geant + NumberUnit.ballon + NumberUnit.ballonDef)
            {
                var newWar = Instantiate(prefabBallonDef, transform.position, Quaternion.identity);
                newWar.GetComponent<DeplacementUnit>().boxCollider = camp;
                newWar.transform.SetParent(SceneControler.Instance.Troupes.transform, true);
                countUnit += 1;
                NumberUnit.unitToSpawn -= 1;
                
            }
        }
    }
    
    
}
