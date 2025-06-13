using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotUI : MonoBehaviour
{
    public Image weaponIcon;
    public TMP_Text weaponNameText;
    public TMP_Text damageText;

    public void SetWeapon(WeaponData weaponData, int upgradeLevel)
    {
        if (weaponData == null)
        {
            weaponIcon.sprite = null;
            weaponNameText.text = "None";
            damageText.text = "-";
            return;
        }

        weaponIcon.sprite = weaponData.icon;
        weaponNameText.text = weaponData.weaponName;
        damageText.text = $"공격력: {weaponData.GetDamageAtLevel(upgradeLevel)}";
    }
}
