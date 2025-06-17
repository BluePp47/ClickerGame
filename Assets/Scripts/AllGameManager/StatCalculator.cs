using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public PlayerData playerData;
    public WeaponData weaponData;

    public float criticalChance = 0.5f;
    public int criticalMultiplier = 2;

    public int GetTotalDamage()
    {
        int baseDamage = playerData.attack + weaponData.baseDamage;
        if (IsCriticalAtk(criticalChance))
        {
            return baseDamage * criticalMultiplier;
        }
        return baseDamage;
    }

    public bool IsCriticalAtk(float criticPer)
    {
        float number = Random.value;
        return number < criticPer;
    }
}
