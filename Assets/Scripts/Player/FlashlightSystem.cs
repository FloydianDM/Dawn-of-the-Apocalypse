using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class FlashlightSystem : MonoBehaviour
    {
        [SerializeField] private float lightFade = 0.1f;
        [SerializeField] private float angleFade = 1f;
        [SerializeField] private float minimumLightIntensity = 5f; 
        [SerializeField] private float minimumLightAngle = 35f;

        private Light _flashLightLight;

        private void Start()
        {   
            _flashLightLight = GetComponent<Light>(); 
        }

        private void Update()
        {
            FadeLight();
            FadeAngle();
        }

        private void FadeLight()
        {
            if (_flashLightLight.intensity <= minimumLightIntensity || !_flashLightLight.isActiveAndEnabled)
            {
                return;
            }

           _flashLightLight.intensity -= lightFade * Time.deltaTime;        
        }

        private void FadeAngle()
        {
            if (_flashLightLight.spotAngle <= minimumLightAngle || !_flashLightLight.isActiveAndEnabled)
            {
                return;
            }

            _flashLightLight.spotAngle -= angleFade * Time.deltaTime;
        }

        public void KillTheLight(bool isLightOn)
        {
            gameObject.SetActive(isLightOn);
        }
    }
}
