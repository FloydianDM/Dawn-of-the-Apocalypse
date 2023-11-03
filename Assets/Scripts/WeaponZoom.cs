using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float zoomedFOV = 30f;
        
        private float _defaultFOV; //default FOV settings from VirtualCamera

        private void Start()
        {
            _defaultFOV = virtualCamera.m_Lens.FieldOfView;
        }

        public void CameraZoom(bool isZoomed)
        {
            if (isZoomed)
            {
               virtualCamera.m_Lens.FieldOfView = zoomedFOV;
            }
            else
            {
                virtualCamera.m_Lens.FieldOfView = _defaultFOV;
            }    
        }
    }
}


