using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Canvas gunReticleCanvas;
        [SerializeField] private Canvas gameOverCanvas;

        public bool isDead;
    
        private void Start()
        {
            gameOverCanvas.enabled = false;
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        
        }
    }
}

