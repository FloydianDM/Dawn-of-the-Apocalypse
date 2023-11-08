using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    /// <summary>
    /// TODO: Revise the script after add different body parts with different HP.
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float enemyHP = 100f;
        public float EnemyHP => enemyHP;

        private float _deathAnimationTime = 1f;
        public bool isDead = false;
        private EnemyAI _enemyAI;
        private Animator _enemyAnimator;
        
        private void Start()
        {
            _enemyAI = GetComponent<EnemyAI>();
            _enemyAnimator = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            _enemyAI.OnDamageTaken();
            enemyHP -= damage;
            
            if (enemyHP <= 0)
            {
                EnemyDeath();
            }
        }

        private void EnemyDeath()
        {
            _enemyAnimator.SetTrigger("die");
            Destroy(gameObject, _deathAnimationTime);
            isDead = true;
        }
    }
}

