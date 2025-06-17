using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UpgType
{
    Critical,
    AutoAttack,
    GoldBonus
}

public class PlayerUpgradeUI : MonoBehaviour
{
    [Header("List")]
    [SerializeField] private List<TMP_Text> criticalLIst;
    [SerializeField] private List<TMP_Text> autoAtkLIst;
    [SerializeField] private List<TMP_Text> goldBonusLIst;
    [Header("Button")]
    [SerializeField] private Button criticalBtn;
    [SerializeField] private Button autoAtkBtn;
    [SerializeField] private Button goldBonusBtn;
    [Header("Others")]
    [SerializeField] private TMP_Text currentGoldTxt;
    [SerializeField] private PlayerUpgradeHandler playerUpgHandler;
    [SerializeField] private PlayerStatsSO statsSO;
    private void Awake()
    {
        playerUpgHandler = new PlayerUpgradeHandler(statsSO);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnUpdateUI += UpdateUI;
        GameManager.Instance.OnUpdateUI += TryUpgrade;
    }
    private void Start()
    {
        criticalBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(criticalLIst, UpgType.Critical));
        autoAtkBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(autoAtkLIst, UpgType.AutoAttack));
        goldBonusBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(goldBonusLIst, UpgType.GoldBonus));
    }
    private void OnDisable()
    {
        GameManager.Instance.OnUpdateUI -= UpdateUI;
        GameManager.Instance.OnUpdateUI -= TryUpgrade;
    }
    public void UpdateUI(List<TMP_Text> txt, UpgType type)
    {
        int currentGold = int.Parse(txt[3].text);

        txt[0].text = playerUpgHandler.GetLvlTitleText(txt[0].text);                 // Lvl Txt
        txt[1].text = playerUpgHandler.GetValueText(txt[0].text, type);              // Value Txt
        txt[2].text = playerUpgHandler.GetCostText(txt[0].text);                  // Cost Txt
        txt[3].text = playerUpgHandler.GetCurrentGoldText(txt[0].text, currentGold); // CurrentGold Txt
    }
    public void RefreshAllUpgrade()
    {
        UpdateUI(criticalLIst, UpgType.Critical);
        UpdateUI(autoAtkLIst, UpgType.AutoAttack);
        UpdateUI(goldBonusLIst, UpgType.GoldBonus);
    }
    #region cost
    public void TryUpgrade(List<TMP_Text> txt, UpgType type)
    {
        int currentGold = int.Parse(txt[3].text);
        int cost = int.Parse(txt[2].text);
        bool canUpgrade = currentGold >= cost;

        Button btn = GetButtonByType(type);
        btn.interactable = canUpgrade;

        txt[2].color = canUpgrade ? Color.white : Color.red;
    }
    private Button GetButtonByType(UpgType type)
    {
        switch (type)
        {
            case UpgType.Critical:
                return criticalBtn;
            case UpgType.AutoAttack:
                return autoAtkBtn;
            case UpgType.GoldBonus:
                return goldBonusBtn;
            default:
                return null;
        }
    }
    #endregion
}
