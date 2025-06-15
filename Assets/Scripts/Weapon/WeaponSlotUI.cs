using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI upgradeCostText;
    public Button buyButton;
    public Button upgradeButton;

    private WeaponData weaponData;
    private System.Action<WeaponData> onBuyCallback;
    private System.Action<WeaponData> onUpgradeCallback;

    public void Set(WeaponData data, bool isOwned, int currentLevel, int playerGold,
                    System.Action<WeaponData> onBuy, System.Action<WeaponData> onUpgrade)
    {
        weaponData = data;
        onBuyCallback = onBuy;
        onUpgradeCallback = onUpgrade;

        if (isOwned)
        {
            iconImage.sprite = data.icon;
            iconImage.color = Color.white;
            nameText.text = data.weaponName;

            int damage = data.GetDamageAtLevel(currentLevel);
            damageText.text = $"+{damage} Damage (Lv.{currentLevel})";

            buyButton.gameObject.SetActive(false);

            int upgradeCost = data.GetUpgradeCost(currentLevel);
            upgradeCostText.text = upgradeCost.ToString();
            upgradeCostText.color = playerGold >= upgradeCost ? Color.black : Color.red;

            upgradeButton.gameObject.SetActive(true);
            upgradeButton.onClick.RemoveAllListeners();
            upgradeButton.onClick.AddListener(() => onUpgradeCallback?.Invoke(weaponData));
        }
        else
        {
            iconImage.sprite = data.icon;
            iconImage.color = new Color(0, 0, 0, 0.3f);
            nameText.text = "???";
            damageText.text = "???";
            upgradeCostText.text = "";
            buyButton.gameObject.SetActive(true);
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() => onBuyCallback?.Invoke(weaponData));

            upgradeButton.gameObject.SetActive(false);
        }
    }
}
