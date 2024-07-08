
using Script.Component;
using Script.Game;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Scenes;
using Unity.Transforms;

public class  BatimentManager : MonoBehaviour
{
    private GameObject _prefabInstance;
    private bool _isFollowing = false;
    private Camera _mainCamera;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask collect;

    private bool _isCas;
    private bool _isCol;

    private void Start()
    {
        
        _mainCamera = Camera.main;
        _isCas = false;
        _isCol = false;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&  _prefabInstance != null )
        {
            if (_isCol)
            {
                InvokeBatGold(_prefabInstance.transform.position);
                Destroy(_prefabInstance);
                _isFollowing = false;
                _isCol = false;
            }
            if (_isCas)
            {
                GameStat.caserne += 1;
                _isFollowing = false;
                _isCas = false;
            }
            

        }
        if (_isFollowing && _prefabInstance != null)
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
            _prefabInstance.transform.position = hit.point;
            var vector3 = _prefabInstance.transform.position;
            vector3.y += 1;
            _prefabInstance.transform.position = vector3;
            
        }
    }

    public void SetBatGold(GameObject bat)
    {
        if (GameStat.collecteur < GameStat.maxCollecteur)
        {
            _prefabInstance = Instantiate(bat, Input.mousePosition, Quaternion.identity);
            _isFollowing = true;
            _isCol = true;
        }
            
    }
    
    public void SetBatCase(GameObject bat)
    {
        if (GameStat.caserne < GameStat.maxCaserne)
        {
            _prefabInstance = Instantiate(bat, Input.mousePosition, Quaternion.identity);
            _isFollowing = true;
            _isCas = true;
        }
            
    }
    
    public void InvokeBatGold(Vector3 position)
    {
        GameStat.collecteur += 1;
        GameStat.positionColl[GameStat.collecteur - 1] = position;
        var query = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(
            typeof(WantToSpawn)
        );

        query.SetSingleton(new WantToSpawn()
        {
            wantToSpawn = true,
            unit = 5,
            position = position
        });
        
    }

}
