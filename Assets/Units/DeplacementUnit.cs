using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class DeplacementUnit : MonoBehaviour
    {
        UnityEngine.Camera mainCamera;
        NavMeshAgent agent;
        public LayerMask ground;

        public bool isCommandedToMove;
        
        private void Start()
        {
            mainCamera = UnityEngine.Camera.main;
            agent = GetComponent<NavMeshAgent>();
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    isCommandedToMove = true;
                    agent.SetDestination(hit.point);
                }
            }

            if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
            {
                isCommandedToMove = false;
            }
        }
    }
}
