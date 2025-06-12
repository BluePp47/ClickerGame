using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;

    public int baseDamage;
    public int[] upgradeDamages;

    public int GetDamageAtLevel(int level)
    {
        return baseDamage + (level < upgradeDamages.Length ? upgradeDamages[level] : 0);
    }
}
