using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] ammoSlots;

    [Serializable]
    private class AmmoSlot 
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // get correct type of ammoSlot for selected weapon from list to operate ammo.
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoType)
            {
                return ammoSlot;
            }
        }

        return null;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        if (GetAmmoSlot(ammoType).ammoAmount == 0) {return;}

        GetAmmoSlot(ammoType).ammoAmount--;
    }

}
