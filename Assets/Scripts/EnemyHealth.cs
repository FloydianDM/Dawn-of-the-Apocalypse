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
        
        public void TakeDamage(float damage)
        {
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


