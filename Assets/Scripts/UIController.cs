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

        public bool isDead;
        private WeaponSwitcher _weaponSwitcher;
    
        private void Start()
        {
            gameOverCanvas.enabled = false;
            _weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        }

        private void Update()
        {
            DeathController();
        }

        private void DeathController()
        {
            gunReticleCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        
            if (isDead)
            {
                gunReticleCanvas.enabled = false;
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
    }
}

