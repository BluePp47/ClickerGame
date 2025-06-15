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

    private int gold = 500;

    void Start()
    {
        openShopButton.onClick.AddListener(OpenShop);
        closeShopButton.onClick.AddListener(CloseShop);

        RefreshUI();
    }

    public int GetGold() => gold;

    public bool TryBuyWeapon(WeaponData weapon)
    {
        if (weaponManager.TryBuyWeapon(weapon, gold, out int cost))
        {
            gold -= cost;
            return true;
        }
        else
        {
            Debug.Log("골드가 부족하거나 이미 소유중입니다.");
            return false;
        }
    }

    public bool TryUpgradeWeapon(WeaponData weapon)
    {
        if (weaponManager.TryUpgradeWeapon(weapon, gold, out int cost))
        {
            gold -= cost;
            return true;
        }
        else
        {
            Debug.Log("골드가 부족하거나 업그레이드 할 수 없습니다.");
            return false;
        }
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
