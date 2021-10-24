using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distToAttack;
    [SerializeField]
    private float viewDist;
    [SerializeField]
    private float detectedDist;
    [SerializeField]
    private float speed;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform EnemyEye;
    [SerializeField]
    private float viewAngle;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        float DistanceToPlayer = Vector3.Distance(target.position, agent.transform.position);
        if (DistanceToPlayer <= detectedDist || EyeView())
        {
            Move();
        }
        
    }

    private bool EyeView()
    {
        float angle = Vector3.Angle(EnemyEye.forward, target.position - EnemyEye.position);
        RaycastHit hit;

        if(Physics.Raycast(EnemyEye.position, target.position - EnemyEye.position, out hit, viewDist))
        {
            if(angle < viewAngle / 2 && hit.transform == target.transform)
            {
                return true;
            }
        }
        return false;
    }

    private void Move()
    {
        agent.SetDestination(target.position);
    }
}
