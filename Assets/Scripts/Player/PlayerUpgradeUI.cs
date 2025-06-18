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
public enum UpgText
{
    Level = 0,
    StatValue,
    Cost,
    Gold
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
    [SerializeField] private PlayerUpgradeHandler playerUpgHandler;
    [SerializeField] private PlayerStatsSO statsSO;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private Attack atk;    
    
    private void Awake()
    {
        playerUpgHandler = new PlayerUpgradeHandler(statsSO);
    }
    private void OnEnable()
    {
        GameManager.Instance.OnUpdateUI += UpdateUI;
        GameManager.Instance.OnUpdateUI += TryUpgrade;
        currencyManager.OnGoldChanged += UIGoldChanged;
    }
    private void Start()
    {
        Init();
        BtnAddListener();
    }
    private void OnDisable()
    {
        GameManager.Instance.OnUpdateUI -= UpdateUI;
        GameManager.Instance.OnUpdateUI -= TryUpgrade;
        currencyManager.OnGoldChanged -= UIGoldChanged;
    }
    public void UpdateUI(List<TMP_Text> txt, UpgType type)
    {
        int currentGold = GameManager.Instance.playerData.gold;

        txt[(int)UpgText.Level].text = playerUpgHandler.GetLvlTitleText(txt[(int)UpgText.Level].text);                    // Lvl Txt
        txt[(int)UpgText.StatValue].text = playerUpgHandler.GetValueText(txt[(int)UpgText.Level].text, type);             // Value Txt
        txt[(int)UpgText.Cost].text = playerUpgHandler.GetCostText(txt[(int)UpgText.Level].text);                         // Cost Txt
        GameManager.Instance.playerData.gold = playerUpgHandler.GetCurrentGoldText(txt[(int)UpgText.Level].text, currentGold);                            // CurrentGold Txt
        if(type == UpgType.AutoAttack)
        {
            atk.SetAutoAtkStat(float.Parse(txt[(int)UpgText.StatValue].text));
        }
        else if(type == UpgType.Critical)
        {
            atk.SetCriticalStat(float.Parse(txt[(int)UpgText.StatValue].text));
        }
        else if(type == UpgType.GoldBonus)
        {
            GameManager.Instance.SetAddGold(float.Parse(txt[(int)UpgText.StatValue].text));
        }
    }
    void Init()
    {
        TryUpgrade(criticalLIst, UpgType.Critical);
        TryUpgrade(autoAtkLIst, UpgType.AutoAttack);
        TryUpgrade(goldBonusLIst, UpgType.GoldBonus);
    }
    void BtnAddListener()
    {
        criticalBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(criticalLIst, UpgType.Critical));
        autoAtkBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(autoAtkLIst, UpgType.AutoAttack));
        goldBonusBtn.onClick.AddListener(() => GameManager.Instance.OnClickUpgrade(goldBonusLIst, UpgType.GoldBonus));
    }
    void UIGoldChanged(int currentGold)
    {
        TryUpgrade(criticalLIst, UpgType.Critical);
        TryUpgrade(autoAtkLIst, UpgType.AutoAttack);
        TryUpgrade(goldBonusLIst, UpgType.GoldBonus);
    }
    #region cost
    public void TryUpgrade(List<TMP_Text> txt, UpgType type)
    {
        int currentGold = GameManager.Instance.playerData.gold;
        int cost = int.Parse(txt[(int)UpgText.Cost].text);
        bool canUpgrade = currentGold >= cost;
        Button btn = GetButtonByType(type);
        btn.interactable = canUpgrade;
        txt[(int)UpgText.Cost].color = canUpgrade ? Color.white : Color.red;
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
