using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class PlayerHealth : MonoBehaviour
    {
        private float _playerHitPoint = 100f;

        public void TakeDamage(float damage)
        {
            if (IsDeath()) return;

            _playerHitPoint -= damage;
        }

        private bool IsDeath()
        {
            if (_playerHitPoint <= 0)
            {
                Debug.Log("Player is dead.");
                return true;
            }

            return false;
        }
    }
}

