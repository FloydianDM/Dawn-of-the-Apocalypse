using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace DawnOfTheApocalypse
{
    /// <summary>
    /// known bug:
    /// MuzzleFlash VFX is not working for second weapon.
    /// Try OnDisable()
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Camera fpCamera;
        [SerializeField] private float shootRange = 100f;
        [SerializeField] private float weaponDamage = 20f;
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private float effectDuration = 0.4f;
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private Ammo ammoSlot;
        [SerializeField] private AmmoType ammoType;
        [SerializeField] private TextMeshProUGUI ammoText;

        public bool isReadyToShoot;

        private void Start()
        {
            isReadyToShoot = true;
        }

        private void Update()
        {
            ChangeAmmoDisplay();
        }

        private void ChangeAmmoDisplay()
        {
            ammoText.text = $"Ammo: {ammoSlot.GetCurrentAmmo(ammoType)}";
        }

        public IEnumerator Shoot()
        {
            isReadyToShoot = false;

            if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
            {
                PlayWeaponEffect();
                ProcessRaycast();
                ammoSlot.ReduceAmmo(ammoType);    
            }
            
            yield return new WaitForSeconds(fireRate);
            isReadyToShoot = true;
        }

        private void PlayWeaponEffect()
        {
            muzzleFlash.Play();
            Debug.Log("Muzzle");
        }

        private void ProcessRaycast()
        {
            RaycastHit hit;
            
            if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, shootRange))
            {
                PlayHitEffect(hit);
                EnemyHealth target = hit.transform.GetComponentInParent<EnemyHealth>();
                if (target == null) return;
                target.TakeDamage(weaponDamage);
                Debug.Log(target.EnemyHP);
            }
        }

        private void PlayHitEffect(RaycastHit hit)
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal), transform.parent);
            impact.GetComponent<ParticleSystem>().Play();
            Destroy(impact, effectDuration);
        }
    }
}
