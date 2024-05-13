using System;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class GoDestination : MonoBehaviour
    {
        public Vector3 target;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _agent.SetDestination(target);
        }
    }
}