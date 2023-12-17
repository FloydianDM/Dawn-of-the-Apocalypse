using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class PlayerHealth : MonoBehaviour
    {
        private float _playerHitPoint = 100f;

        private UIController _uiController;

        private void Start()
        {
            _uiController = FindObjectOfType<UIController>();
        }

        public void TakeDamage(float damage)
        {
            if (IsDeath()) return;

            _playerHitPoint -= damage;
            StartCoroutine(_uiController.ControlDamageCanvas());
        }

        private bool IsDeath()
        {
            if (_playerHitPoint <= 0)
            {
                _uiController.IsDead = true;
                return true;
            }
            
            return false;
        }
    }
}

