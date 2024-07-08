using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DeplacementUnit : MonoBehaviour
{
    public BoxCollider boxCollider;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        Bounds bounds = boxCollider.bounds;

        // Générer une position aléatoire à l'intérieur des limites
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        var randomPosition = new Vector3(x, 3, z);
        agent.SetDestination(randomPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Destroy(agent);
                }
            }
        }
    }
}
