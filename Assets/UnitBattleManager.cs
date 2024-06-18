using System;
using System.Collections;
using System.Collections.Generic;
using Script.Component;
using Unity.Entities;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }
    public int numberWar;
    public int numberArr;
    private Camera _mainCamera;
    [SerializeField] private LayerMask ground;
    private bool _isFollowing;
    private bool _isWar;
    private bool _isArr;
    private GameObject prefabInstance;
    private Entity entity;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        World.DefaultGameObjectInjectionWorld.EntityManager.CreateSingleton<WantToSpawn>();
        numberArr = NumberUnit.archer;
        numberWar = NumberUnit.guerrier;
        _mainCamera = Camera.main;
    }

    public void NewScene()
    {
        NumberUnit.archer = numberArr;
        NumberUnit.guerrier = numberWar; 
        
        
        // Charger la nouvelle scène
        SceneManager.LoadScene("CombatScene");
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isFollowing = false;
            _isWar = false;
            _isArr = false;
            Destroy(prefabInstance);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (_isWar)
            {
                Vector3 mousePos = Input.mousePosition;
                Ray ray = _mainCamera.ScreenPointToRay(mousePos);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,ground))
                {
                    InvokeWar(hit.point);
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
                    InvokeArr(hit.point);
                    numberArr -= 1;
                }
                if (numberArr == 0)
                {
                    _isFollowing = false;
                    _isArr = false;
                    Destroy(prefabInstance);
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
        if (numberWar > 0)
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
    
    
    
    
}
