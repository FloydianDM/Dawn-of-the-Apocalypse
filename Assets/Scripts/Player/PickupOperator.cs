using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class PickupOperator : MonoBehaviour
    {
        // Add all pickups to this script

        private FlashlightSystem _flashLightSystem;

        private void Start()
        {
            _flashLightSystem = GetComponentInChildren<FlashlightSystem>();
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Battery"))
            {
                _flashLightSystem.RestoreLight();
                Destroy(other.gameObject);
            }
        }
    }   
}


