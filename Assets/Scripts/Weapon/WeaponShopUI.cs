using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject weaponSlotPrefab;
    public WeaponManager weaponManager;
    public WeaponMainUI mainWeaponUI;
    public WeaponUIManager uiManager;

    public void RefreshUI()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (var weapon in weaponManager.allWeapons)
        {
            GameObject slotGO = Instantiate(weaponSlotPrefab, contentParent);
            WeaponSlotUI slot = slotGO.GetComponent<WeaponSlotUI>();
            bool isOwned = weaponManager.ownedWeapons.Contains(weapon);
            int level = isOwned ? weaponManager.GetWeaponLevel(weapon) : 0;

            slot.Set(weapon, isOwned, level, uiManager.GetGold(),
                TryBuyWeapon, TryUpgradeWeapon);
        }
    }

    private void TryBuyWeapon(WeaponData weapon)
    {
        if (uiManager.TryBuyWeapon(weapon))
        {
            RefreshUI();
            mainWeaponUI.UpdateUI();
            uiManager.RefreshUI();
        }
    }

    private void TryUpgradeWeapon(WeaponData weapon)
    {
        if (uiManager.TryUpgradeWeapon(weapon))
        {
            RefreshUI();
            mainWeaponUI.UpdateUI();
            uiManager.RefreshUI();
        }
    }
}