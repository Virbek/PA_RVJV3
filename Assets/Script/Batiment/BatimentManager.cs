
using Script.Component;
using Script.Game;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Scenes;
using Unity.Transforms;

public class BatimentManager : MonoBehaviour
{
    private GameObject _prefabInstance;
    private bool _isFollowing = false;
    private Camera _mainCamera;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask collect;

    private void Start()
    {
        
        _mainCamera = Camera.main;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&  _prefabInstance != null )
        {
            InvokeBatGold(_prefabInstance.transform.position);
            Destroy(_prefabInstance);
            _isFollowing = false;

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

    public void setBat(GameObject bat)
    {
        _prefabInstance = Instantiate(bat, Input.mousePosition, Quaternion.identity);
        _isFollowing = true;
            
    }
    
    public void InvokeBatGold(Vector3 position)
    {
        GameStat.collecteur += 1;
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
