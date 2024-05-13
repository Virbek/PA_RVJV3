using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Units;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class UnitAttackState : StateMachineBehaviour
{
    
    NavMeshAgent agent;
    AttackController attackController;

    public float stopAttackingDistance = 1.2f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        attackController = animator.GetComponent<AttackController>();
        attackController.SetAttackMaterial();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attackController.targetToAttack != null && animator.transform.GetComponent<DeplacementUnit>().isCommandedToMove == false)
        {
            LookAtPlayer();
            
            agent.SetDestination(attackController.targetToAttack.position);

            var damageInInflict = attackController.unitDamage;

            attackController.targetToAttack.GetComponent<Enemy>().RecieveDamage(damageInInflict);

            float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
            if (distanceFromTarget > stopAttackingDistance || attackController.targetToAttack == null)
            {
                agent.SetDestination(animator.transform.position);
                animator.SetBool("isAttacking", false);
            }
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = attackController.targetToAttack.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}

