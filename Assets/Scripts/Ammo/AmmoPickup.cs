using UnityEngine;

namespace DawnOfTheApocalypse
{
    public class AmmoPickup : MonoBehaviour
   {
      [SerializeField] private int pickedAmmoAmount = 10;
      [SerializeField] AmmoType ammoType;

      private Ammo _ammo;

      private void Start()
      {
         _ammo = FindObjectOfType<Ammo>();
      }

      private void OnTriggerEnter(Collider other) 
      {
         if (!other.CompareTag("Player")){ return; }

         Debug.Log("PICKED!");
         _ammo.IncreaseAmmo(ammoType, pickedAmmoAmount);
         Destroy(gameObject);
      }
   }
}


