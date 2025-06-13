using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponData> allWeapons;
    public List<WeaponData> ownedWeapons = new();

    public bool TryBuyWeapon(WeaponData weapon)
    {
        if (ownedWeapons.Contains(weapon)) return false;

        // TODO: 골드 확인 로직 넣기
        ownedWeapons.Add(weapon);
        return true;
    }

    public int GetTotalBonusDamage()
    {
        int total = 0;
        foreach (var w in ownedWeapons)
            total += w.bonusDamage;
        return total;
    }

    public WeaponData GetBestWeapon()
    {
        WeaponData best = null;
        int maxDamage = int.MinValue;

        foreach (var w in ownedWeapons)
        {
            if (w.bonusDamage > maxDamage)
            {
                maxDamage = w.bonusDamage;
                best = w;
            }
        }

        return best;
    }
}
