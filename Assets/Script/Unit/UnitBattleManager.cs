using System;
using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Script.Game;
using Unity.Entities;
using UnityEngine;

public class UnitBattleManager : MonoBehaviour
{
    public int numberWar;
    public int numberArr;
    public int numberGea;
    private Camera _mainCamera;
    [SerializeField] private LayerMask ground;
    private bool _isFollowing;
    private bool _isWar;
    private bool _isArr;
    private bool _isGea;
    private GameObject prefabInstance;
    private Entity entity;
    private float timeToSpawn;
    [SerializeField] private float delaySpawn;
    [SerializeField] private GameObject geant;

    private void Start()
    {
        timeToSpawn = 0f;
        numberArr = NumberUnit.archer;
        numberWar = NumberUnit.guerrier;
        numberGea = NumberUnit.geant;
        _mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (GameStat.NiveauHdv > 1)
        {
            geant.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _isFollowing = false;
            _isWar = false;
            _isArr = false;
            _isGea = false;
            Destroy(prefabInstance);
        }
        
        if (Input.GetMouseButton(1))
        {
            timeToSpawn += Time.deltaTime;
            if (timeToSpawn >= delaySpawn || Input.GetMouseButtonDown(1))
            {
                timeToSpawn = 0;
                if (_isWar)
                {
                    Vector3 mousePos = Input.mousePosition;
                    Ray ray = _mainCamera.ScreenPointToRay(mousePos);
                    if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,ground))
                    {
                        InvokeWar(prefabInstance.transform.position);
                        numberWar -= 1;
                    }

                    if (numberWar == 0)
                    {
                        _isFollowing = false;
                        _isWar = false;
                        Destroy(prefabInstance);
                    }
                }

                if (_isArr)
                {
                    Vector3 mousePos = Input.mousePosition;
                    Ray ray = _mainCamera.ScreenPointToRay(mousePos);
                    if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,ground))
                    {
                        InvokeArr(prefabInstance.transform.position);
                        numberArr -= 1;
                    }
                    if (numberArr == 0)
                    {
                        _isFollowing = false;
                        _isArr = false;
                        Destroy(prefabInstance);
                    }
                }
                if (_isGea)
                {
                    Vector3 mousePos = Input.mousePosition;
                    Ray ray = _mainCamera.ScreenPointToRay(mousePos);
                    if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,ground))
                    {
                        InvokeGea(prefabInstance.transform.position);
                        numberGea -= 1;
                    }
                    if (numberGea == 0)
                    {
                        _isFollowing = false;
                        _isGea = false;
                        Destroy(prefabInstance);
                    }
                }
            }

        }
        if (_isFollowing && prefabInstance != null)
        {
            FollowMouse();
        }
        
    }
    
    private void FollowMouse()
    {
        
        Vector3 mousePos = Input.mousePosition;
        Ray ray = _mainCamera.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,ground))
        {
            prefabInstance.transform.position = hit.point;
            var vector3 = prefabInstance.transform.position;
            vector3.y += 1;
            prefabInstance.transform.position = vector3;

        }
    }
    
    public void SpawnWar(GameObject war)
    {
        if (numberWar > 0)
        {
            prefabInstance = Instantiate(war, Input.mousePosition, Quaternion.identity);
            _isFollowing = true;
            _isWar = true;
        }
        
    }

    public void InvokeWar(Vector3 position)
    {
        
        var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
            typeof(WantToSpawn)
        );

        query.SetSingleton(new WantToSpawn()
        {
            wantToSpawn = true,
            unit = 0,
            position = position
        });
        
    }
    
    public void SpawnArr(GameObject arr)
    {
        if (numberArr > 0)
        {
            prefabInstance = Instantiate(arr, Input.mousePosition, Quaternion.identity);
            _isFollowing = true;
            _isArr = true;
        }
        
    }

    public void InvokeArr(Vector3 position)
    {
        
        var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
            typeof(WantToSpawn)
        );

        query.SetSingleton(new WantToSpawn()
        {
            wantToSpawn = true,
            unit = 1,
            position = position
        });
        
    }
    
    public void SpawnGea(GameObject gea)
    {
        if (numberGea > 0)
        {
            prefabInstance = Instantiate(gea, Input.mousePosition, Quaternion.identity);
            _isFollowing = true;
            _isGea = true;
        }
        
    }

    public void InvokeGea(Vector3 position)
    {
        
        var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
            typeof(WantToSpawn)
        );

        query.SetSingleton(new WantToSpawn()
        {
            wantToSpawn = true,
            unit = 2,
            position = position
        });
        
    }
    
    
    
    
}