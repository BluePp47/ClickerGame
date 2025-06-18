using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public GameObject weaponMainUI;
    public GameObject shopUI;

    public Button openShopButton;
    public Button closeShopButton;

    public WeaponManager weaponManager;
    public WeaponMainUI weaponMainUIComponent;
    public WeaponShopUI weaponShopUI;

    public CurrencyManager currencyManager;

    void Start()
    {
        openShopButton.onClick.AddListener(OpenShop);
        closeShopButton.onClick.AddListener(CloseShop);

        RefreshUI();
    }

    public int GetGold()
    {
        return currencyManager.playerData.gold;
    }

    public bool TryBuyWeapon(WeaponData weapon)
    {
        int cost;
        if (weaponManager.TryBuyWeapon(weapon, GetGold(), out cost))
        {
            if (currencyManager.SubtractGold(cost))
                return true;
        }
        return false;
    }

    public bool TryUpgradeWeapon(WeaponData weapon)
    {
        int cost;
        if (weaponManager.TryUpgradeWeapon(weapon, GetGold(), out cost))
        {
            if (currencyManager.SubtractGold(cost))
                return true;
        }
        return false;
    }

    void OpenShop()
    {
        shopUI.SetActive(true);
        weaponShopUI.RefreshUI();
    }

    void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void RefreshUI()
    {
        weaponMainUIComponent.UpdateUI();
        weaponShopUI.RefreshUI();
    }
}
