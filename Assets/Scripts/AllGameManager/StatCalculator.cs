using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public PlayerData playerData;
    public WeaponManager weaponManager;

    public float criticalChance = 0.5f;
    public int criticalMultiplier = 2;

    public int GetTotalDamage()
    {
        int playerBase = playerData.attack;

        WeaponData bestWeapon = weaponManager.GetBestWeapon();

        int weaponDamage = 0;
        if (bestWeapon != null)
        {
            weaponDamage = weaponManager.GetWeaponDamage(bestWeapon);
        }

        int totalDamage = playerBase + weaponDamage;

        if (IsCriticalAtk(criticalChance))
        {
            return totalDamage * criticalMultiplier;
        }

        return totalDamage;
    }

    public bool IsCriticalAtk(float criticPer)
    {
        float number = Random.value;
        return number < criticPer;
    }
}
