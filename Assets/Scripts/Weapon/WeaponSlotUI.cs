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
    public Button buyButton;

    private WeaponData weaponData;
    private System.Action<WeaponData> onBuyCallback;

    public void Set(WeaponData data, bool isOwned, System.Action<WeaponData> onBuy)
    {
        weaponData = data;
        onBuyCallback = onBuy;

        if (isOwned)
        {
            iconImage.sprite = data.icon;
            nameText.text = data.weaponName;
            damageText.text = $"+{data.bonusDamage} Damage";
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            iconImage.sprite = data.icon;
            iconImage.color = new Color(0, 0, 0, 0.3f);
            nameText.text = "???";
            damageText.text = "???";
            buyButton.gameObject.SetActive(true);
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() => onBuyCallback?.Invoke(weaponData));
        }
        weaponIcon.sprite = weaponData.icon;
        weaponNameText.text = weaponData.weaponName;
        //damageText.text = $"공격력: {weaponData.GetDamageAtLevel(upgradeLevel)}";
    }
}
