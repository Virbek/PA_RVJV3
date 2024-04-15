using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class DeplacementUnit : MonoBehaviour
    {
        private UnityEngine.Camera _mainCamera;
        private NavMeshAgent _agent;
        public LayerMask ground;
        private void Start()
        {
            _mainCamera = UnityEngine.Camera.main;
            _agent = GetComponent<NavMeshAgent>();
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
    }
}
