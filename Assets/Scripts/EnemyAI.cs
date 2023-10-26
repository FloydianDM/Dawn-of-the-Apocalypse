using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    
    private NavMeshAgent _navMeshAgent;
    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoked = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        _navMeshAgent.SetDestination(target.position);
        DecideChasing();
        DecideEngage();
    }

    private void DecideEngage()
    {
        if (_isProvoked)
        {
            EngageTarget();
        }
    }

    private void DecideChasing()
    {
        _navMeshAgent.isStopped = ShouldStop();
    }
    
    private void EngageTarget()
    {
        
    }
    
    private bool ShouldStop()
    {
        MeasureDistance();
        
        if (_distanceToTarget <= chaseRange)
        {
            return false;
        }
        
        return true;
    }

    private void MeasureDistance()
    {
        _distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
