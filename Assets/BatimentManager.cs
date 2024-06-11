
using Script.Component;
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
        if (Input.GetMouseButtonDown(0))
        {
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
            
        }
    }

    public void SetBat(GameObject prefab)
    {
        
        _prefabInstance = Instantiate(prefab, Input.mousePosition, Quaternion.identity);
        _isFollowing = true;
    }

}
