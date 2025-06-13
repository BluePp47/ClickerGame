using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject weaponSlotPrefab;
    public WeaponManager weaponManager;

    private void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        foreach (var weapon in weaponManager.allWeapons)
        {
            GameObject slotGO = Instantiate(weaponSlotPrefab, contentParent);
            WeaponSlotUI slot = slotGO.GetComponent<WeaponSlotUI>();
            bool isOwned = weaponManager.ownedWeapons.Contains(weapon);

            slot.Set(weapon, isOwned, TryBuyWeapon);
        }
    }

    private void TryBuyWeapon(WeaponData weapon)
    {
        if (weaponManager.TryBuyWeapon(weapon))
        {
            RefreshUI();
        }
    }
}
