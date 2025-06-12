using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponData> allWeapons;
    public List<WeaponData> ownedWeapons;

    public int GetTotalBonusDamage()
    {
        int total = 0;
        foreach (var weapon in ownedWeapons)
        {
            total += weapon.bonusDamage;
        }
        return total;
    }

    public bool TryBuyWeapon(WeaponData weapon)
    {
        if (ownedWeapons.Contains(weapon))
            return false;

        // gold체크하고 감소 코드

        ownedWeapons.Add(weapon);
        return true;
    }
}
