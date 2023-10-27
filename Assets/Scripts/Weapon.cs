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
        [SerializeField] private float weaponDamage = 20f;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private float effectDuration = 0.4f;

        public void Shoot()
        {
            PlayWeaponEffect();
            ProcessRaycast();
        }

        private void PlayWeaponEffect()
        {
            muzzleFlash.Play();
        }

        private void ProcessRaycast()
        {
            RaycastHit hit;
            
            if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, shootRange))
            {
                PlayHitEffect(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
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
