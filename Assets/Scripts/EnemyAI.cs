using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DawnOfTheApocalypse
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float chaseRange = 5f;
        
        private NavMeshAgent _navMeshAgent;
        private float _distanceToTarget = Mathf.Infinity;
        private bool _isProvoked = false;
        
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            MeasureDistance();
    
            if (_isProvoked)
            {
                EngageTarget();
            }
        }
    
        private void EngageTarget()
        {
            if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }
            else if (_distanceToTarget < _navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }
        }
        
        private void ChaseTarget()
        { 
            _navMeshAgent.SetDestination(target.position);
        }
    
        private void AttackTarget()
        {
            // TODO: found bug: Attack executes even if the game object destroyed.
            Debug.Log("Attack!");
        }
    
        private void MeasureDistance()
        {
            _distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));
    
            if (_distanceToTarget <= chaseRange)
            {
                _isProvoked = true;
            }
            else
            {
                _isProvoked = false;
            }
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}


