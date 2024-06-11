using System;
using System.Collections;
using System.Collections.Generic;
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
    private GameObject prefabInstance;
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
            numberWar -= 1;
        }
        
    }
    
    
    
    
}
