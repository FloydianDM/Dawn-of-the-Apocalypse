using System.Collections;
using System.Collections.Generic;
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

        public bool isDead = false;
        private EnemyAI _enemyAI;
        
        private void Start()
        {
            _enemyAI = GetComponent<EnemyAI>();

        }
        public void TakeDamage(float damage)
        {
            _enemyAI.OnDamageTaken();
            enemyHP -= damage;
            EnemyDeath();
        }

        private void EnemyDeath()
        {
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                isDead = true;
            }
        }
    }
}


