using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    /// <summary>
    /// TODO: Fix WeaponSwitcher enabled = false
    /// </summary>
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Canvas gunReticleCanvas;
        [SerializeField] private Canvas gameOverCanvas;
        [SerializeField] private Canvas ammoCanvas;
        [SerializeField] private Canvas damageCanvas;

        public bool IsDead;
        public bool IsTakeDamage;
        private WeaponSwitcher _weaponSwitcher;
    
        private void Start()
        {
            gameOverCanvas.enabled = false;
            damageCanvas.enabled = false;
            _weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        }

        private void Update()
        {
            ControlDeath();
        }

        private void ControlDeath()
        {
            gunReticleCanvas.enabled = true;
            ammoCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        
            if (IsDead)
            {
                gunReticleCanvas.enabled = false;
                ammoCanvas.enabled = false;
                gameOverCanvas.enabled = true;
                
                Time.timeScale = 0;
                _weaponSwitcher.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                _weaponSwitcher.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public IEnumerator ControlDamageCanvas()
        {            
            damageCanvas.enabled = true;
        
            yield return new WaitForSeconds(0.2f);

            damageCanvas.enabled = false;
        }
    }
}

