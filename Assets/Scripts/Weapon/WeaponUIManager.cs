using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public GameObject weaponMainUI;
    public GameObject shopUI;

    public Button openShopButton;
    public Button closeShopButton;

    public Button buyWeaponButton;
    public Button upgradeWeaponButton;

    private bool weaponPurchased = false;
    private int weaponLevel = 1;
    private int baseDamage = 10;

    void Start()
    {
        openShopButton.onClick.AddListener(OpenShop);
        closeShopButton.onClick.AddListener(CloseShop);
        buyWeaponButton.onClick.AddListener(BuyWeapon);
        upgradeWeaponButton.onClick.AddListener(UpgradeWeapon);

        upgradeWeaponButton.gameObject.SetActive(false);
    }

    void OpenShop()
    {
        shopUI.SetActive(true);
    }

    void CloseShop()
    {
        shopUI.SetActive(false);
    }

    void BuyWeapon()
    {
        if (!weaponPurchased)
        {
            weaponPurchased = true;

            upgradeWeaponButton.gameObject.SetActive(true);
        }
    }

    void UpgradeWeapon()
    {
        if (weaponPurchased)
        {
            weaponLevel++;
        }
    }
}
