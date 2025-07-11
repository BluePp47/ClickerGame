﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMainUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public WeaponManager weaponManager;

    public void UpdateUI()
    {
        WeaponData best = weaponManager.GetBestWeapon();
        if (best != null)
        {
            iconImage.sprite = best.icon;
            iconImage.color = Color.white;
            nameText.text = best.weaponName;

            int level = weaponManager.GetWeaponLevel(best);
            int damage = best.GetDamageAtLevel(level);
        }
        else
        {
            iconImage.color = Color.clear;
            nameText.text = "무기 없음";
        }
    }
}
