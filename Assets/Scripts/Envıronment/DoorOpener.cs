using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class DoorOpener : MonoBehaviour
    {
        public bool IsExecuteOpening; // pass this bool value to FirstPersonController.cs
        public bool IsTouched;

        [SerializeField] private bool _isOpened;
        private Vector3 _originalPosition = new();

        private void Start()
        {
            _originalPosition = transform.position;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (!other.CompareTag("Player")) 
            {
                return;
            }

            if (IsExecuteOpening && !_isOpened)
            {
                _isOpened = true;
                Debug.Log("Door interacted");
                transform.position += new Vector3(10,0,0);
            }    
            else if (IsExecuteOpening && _isOpened)
            {
                _isOpened = false;
                Debug.Log("Door interacted");
                transform.position = _originalPosition;
            }

            IsExecuteOpening = false;
        }
    }
}

