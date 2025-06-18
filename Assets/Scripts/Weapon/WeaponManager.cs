using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponData> allWeapons;
    public WeaponData defaultWeapon;
    public List<WeaponData> ownedWeapons = new();
    public Dictionary<WeaponData, int> weaponLevels = new();

    void Awake()
    {
        if (defaultWeapon != null && !ownedWeapons.Contains(defaultWeapon))
        {
            ownedWeapons.Add(defaultWeapon);
            weaponLevels[defaultWeapon] = 1;
        }
    }

    public bool TryBuyWeapon(WeaponData weapon, int playerGold, out int cost)
    {
        cost = weapon.basePrice;
        if (ownedWeapons.Contains(weapon))
            return false;

        if (playerGold < cost)
            return false;

        ownedWeapons.Add(weapon);
        weaponLevels[weapon] = 1;
        return true;
    }

    public bool TryUpgradeWeapon(WeaponData weapon, int playerGold, out int cost)
    {
        if (weapon == null || !ownedWeapons.Contains(weapon))
        {
            cost = 0;
            return false;
        }

        int currentLevel = GetWeaponLevel(weapon);
        cost = weapon.GetUpgradeCost(currentLevel);

        if (playerGold < cost)
            return false;

        weaponLevels[weapon] = currentLevel + 1;
        return true;
    }

    public int GetWeaponLevel(WeaponData weapon)
    {
        return weaponLevels.ContainsKey(weapon) ? weaponLevels[weapon] : 0;
    }

    public WeaponData GetBestWeapon()
    {
        WeaponData best = null;
        int maxDamage = int.MinValue;

        foreach (var weapon in ownedWeapons)
        {
            int level = GetWeaponLevel(weapon);
            int dmg = weapon.GetDamageAtLevel(level);
            if (dmg > maxDamage)
            {
                best = weapon;
                maxDamage = dmg;
            }
        }

        return best;
    }

    public int GetWeaponDamage(WeaponData weapon)
    {
        if (!ownedWeapons.Contains(weapon)) return 0;
        int level = GetWeaponLevel(weapon);
        return weapon.GetDamageAtLevel(level);
    }

}
