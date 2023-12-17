using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float damage = 40f;

        private PlayerHealth _target;
        
        private void Start()
        {
            _target = FindObjectOfType<PlayerHealth>();
        }

        public void AttackHitEvent()
        {
            if (_target == null) return;
            
            _target.TakeDamage(damage);
        }
    }
}

