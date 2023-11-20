using UnityEngine;
using UnityEngine.UI;
using System;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		// my modifications to default input system
		public bool shoot;
		public bool zoom;
		public float switchValue; // have not completely implemented yet
		public bool previousWeapon; 
		public bool nextWeapon;
		public bool interact;
		public bool switchFlashLight;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Sensitivity")]
		[SerializeField] private float mouseSensitivity = 1f;
		[SerializeField] private float zoomInMouseSensitivity = 0.5f;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			var input = value.Get<Vector2>();
			
			if(cursorInputForLook)
			{
				if (zoom) // mouse sensitivity modification
				{
					input *= zoomInMouseSensitivity;	
				}
				else
				{
					input *= mouseSensitivity;
				}

				LookInput(input);
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnFire(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnZoom(InputValue value)
		{
			ZoomInput(value.isPressed);
		}

		public void OnSwitchWeapon(InputValue value)
		{
			switchValue = value.Get<float>();
		}

		public void OnPreviousWeapon(InputValue value)
		{
			PreviousWeaponInput(value.isPressed);	
		}

		public void OnNextWeapon(InputValue value)
		{
			NextWeaponInput(value.isPressed);	
		}

		public void OnInteract(InputValue value)
		{
			InteractInput(value.isPressed);
			Debug.Log("Interact");
		}

		public void OnSwitchFlashlight(InputValue value)
		{
			SwitchFlashLightInput(value.isPressed);
			Debug.Log("Switch Light");
		}

#endif



        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}

		public void ZoomInput(bool newZoomState)
        {
            zoom = newZoomState;
        }

		private void PreviousWeaponInput(bool newPreviousWeaponState)
        {
            previousWeapon = newPreviousWeaponState;
        }

		private void NextWeaponInput(bool newNextWeaponState)
		{
			nextWeapon = newNextWeaponState;
		}

		private void InteractInput(bool interactionState)
		{
			interact = interactionState;
		}

		private void SwitchFlashLightInput(bool switchFlashLightState)
		{
			switchFlashLight = switchFlashLightState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}