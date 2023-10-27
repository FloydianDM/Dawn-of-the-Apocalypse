using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;


namespace DawnOfTheApocalypse
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera fpCamera;
        [SerializeField] private float shootRange = 100f;
        
        private void Update()
        {
            
        }

        public void Shoot()
        {
            RaycastHit hit;
            Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit ,shootRange);
            Debug.Log("I hit " + hit.transform.name );
        }
    }
}
