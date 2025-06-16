using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text currentGoldTxt;
    [Header("Critical")]
    [SerializeField] private TMP_Text critLvlTitleTxt;
    [SerializeField] private TMP_Text critValueTxt;
    [SerializeField] private TMP_Text critLvlUpTxt;
    [Header("AutoAtk")]
    [SerializeField] private TMP_Text autoAtkLvlTitleTxt;
    [SerializeField] private TMP_Text autoAtkValueTxt;
    [SerializeField] private TMP_Text autoAtkLvlUpTxt;
    [Header("GoldBonus")]
    [SerializeField] private TMP_Text goldBonusLvlTitleTxt;
    [SerializeField] private TMP_Text goldBonusValueTxt;
    [SerializeField] private TMP_Text goldBonusLvlUpTxt;
    [Header("Button")]
    [SerializeField] private Button criticalBtn;
    [SerializeField] private Button autoAtkBtn;
    [SerializeField] private Button goldBonusBtn;

    [SerializeField] private PlayerUpgradeHandler playerUpgHandler;

    private void Awake()
    {
        playerUpgHandler = new PlayerUpgradeHandler();
    }
    private void OnEnable()
    {
        // GM Rename OnAutoAtkSpdUpg -> OnAutoAtkUpg

        GameManager.Instance.OnTestUpg += UpdateUI;
        //GameManager.Instance.OnCriticalUpg += UpdateCritStatsUI;
        //GameManager.Instance.OnAutoAtkSpdUpg += UpdateAutoAtkStateUI;
        //GameManager.Instance.OnGoldBonusUpg += UpdateGoldBonusStatsUI;
    }
    private void Start()
    {
        List<TMP_Text> criticalLIst = new List<TMP_Text> { critLvlTitleTxt, critValueTxt, critLvlUpTxt, currentGoldTxt };
        List<TMP_Text> autoAtkLIst = new List<TMP_Text> { autoAtkLvlTitleTxt, autoAtkValueTxt, autoAtkLvlUpTxt, currentGoldTxt };
        List<TMP_Text> goldBonusLIst = new List<TMP_Text> { goldBonusLvlTitleTxt, goldBonusValueTxt, goldBonusLvlUpTxt, currentGoldTxt };
        criticalBtn.onClick.AddListener(() => UpdateUI(criticalLIst));
        autoAtkBtn.onClick.AddListener(() => UpdateUI(autoAtkLIst));
        goldBonusBtn.onClick.AddListener(() => UpdateUI(goldBonusLIst));
    }
    private void OnDisable()
    {
        GameManager.Instance.OnTestUpg -= UpdateUI;
        //GameManager.Instance.OnCriticalUpg -= UpdateCritStatsUI;
        //GameManager.Instance.OnAutoAtkSpdUpg -= UpdateAutoAtkStateUI;
        //GameManager.Instance.OnGoldBonusUpg -= UpdateGoldBonusStatsUI;
    }
    public void UpdateUI(List<TMP_Text> txt)
    {
        txt[0].text = playerUpgHandler.GetLvlTitleText(txt[0].text);
        txt[1].text = playerUpgHandler.GetValueText(txt[1].text);
        txt[2].text = playerUpgHandler.GetLvlCostText(txt[2].text);
        txt[3].text = playerUpgHandler.GetCurrentGoldText(txt[3].text);
    }

}
