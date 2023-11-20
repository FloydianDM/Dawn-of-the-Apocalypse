using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class WeaponSwitcher : MonoBehaviour
    {
        // TODO: Finish scroll wheel implementation
        
        [SerializeField] private int currentWeaponIndex = 0;
        public int CurrentWeaponIndex => currentWeaponIndex; // getter for using weapon index in input system

        private int _weaponIndex = 0;
        public int WeaponIndex => _weaponIndex;
        private Dictionary<int, Transform> _weapons = new();

        private void Start()
        {
            SetWeaponActive(currentWeaponIndex);
        }

        public void SetWeaponActive(int index)
        {
            foreach (Transform weapon in gameObject.transform)
            {
                weapon.gameObject.SetActive(false);
                _weapons.Add(_weaponIndex, weapon);
                _weaponIndex++;
            }

            Debug.Log(_weapons[index].name);
            _weapons[index].gameObject.SetActive(true);
            currentWeaponIndex = index;
        }   
    }
}

