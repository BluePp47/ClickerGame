using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public int baseDamage;
    public int[] bonusPerLevel;
    public int basePrice;

    public int GetDamageAtLevel(int level)
    {
        if (level < 0) return baseDamage;
        if (bonusPerLevel == null || bonusPerLevel.Length == 0)
            return baseDamage;

        if (level < bonusPerLevel.Length)
            return baseDamage + bonusPerLevel[level];
        else
            return baseDamage + bonusPerLevel[bonusPerLevel.Length - 1];
    }

    public int GetUpgradeCost(int currentLevel)
    {
        return basePrice + currentLevel * 50;
    }
}