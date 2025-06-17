using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;
    public int baseDamage;
    public int damageIncreasePerLevel;
    public int basePrice;

    public int GetDamageAtLevel(int level)
    {
        if (level <= 0) return baseDamage;
        return baseDamage + damageIncreasePerLevel * (level - 1);
    }

    public int GetUpgradeCost(int currentLevel)
    {
        return basePrice + currentLevel * 50;
    }
}