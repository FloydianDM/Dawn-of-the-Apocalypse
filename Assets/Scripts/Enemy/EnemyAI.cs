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
        [SerializeField] private float turnSpeed = 2f;

        private EnemyHealth _enemyHealth;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private float _distanceToTarget = Mathf.Infinity;
        private bool _isProvoked;
        private bool _isDamageTaken;

        private void Start()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            if (_enemyHealth.isDead)
            {
                this.enabled = false;
                _navMeshAgent.enabled = false;
            }
            
            MeasureDistance();
    
            if (_isProvoked)
            {
                EngageTarget();
            }
        }

        public void OnDamageTaken()
        {
            _isDamageTaken = true;
        }
    
        private void EngageTarget()
        {
            FaceTarget();
            
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
            _animator.SetBool("attack", false);
            _animator.SetTrigger("move");       
            _navMeshAgent.SetDestination(target.position);
  
        }
    
        private void AttackTarget()
        {
            _animator.SetBool("attack", true);
        }
    
        private void MeasureDistance()
        {
            _distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));
    
            if (_distanceToTarget <= chaseRange || _isDamageTaken)
            {
                _isProvoked = true;
            }
            else
            {
                _isProvoked = false;
            }
        }

        private void FaceTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}


