using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum UpgType
{
    Critical,
    AutoAtk,
    GoldBonus
}
public class PlayerUpgradeUI : MonoBehaviour
{
    // PlayerUpg Observer

    // 추후 리팩토링
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
    // 리스트로 받기
    [SerializeField] private List<TMP_Text> testcritBtn;

    [SerializeField] private Button btn;
    [SerializeField] private PlayerUpgradeHandler playerUpgHandler;

    private void OnEnable()
    {
        // GM Rename OnAutoAtkSpdUpg -> OnAutoAtkUpg

        GameManager.Instance.OnTestUpg += UpdateUI;
        //GameManager.Instance.OnCriticalUpg += UpdateCritStatsUI;
        GameManager.Instance.OnAutoAtkSpdUpg += UpdateAutoAtkStateUI;
        GameManager.Instance.OnGoldBonusUpg += UpdateGoldBonusStatsUI;
    }
    private void Start()
    {
        List<TMP_Text> testlist = new List<TMP_Text> { critLvlTitleTxt, critValueTxt, autoAtkLvlUpTxt, currentGoldTxt };
        btn.onClick.AddListener(() => UpdateUI(testlist));
    }
    private void OnDisable()
    {
        GameManager.Instance.OnTestUpg -= UpdateUI;
        GameManager.Instance.OnCriticalUpg -= UpdateCritStatsUI;
        GameManager.Instance.OnAutoAtkSpdUpg -= UpdateAutoAtkStateUI;
        GameManager.Instance.OnGoldBonusUpg -= UpdateGoldBonusStatsUI;
    }
    public void UpdateUI(List<TMP_Text> txt)
    {
        txt[0].text = playerUpgHandler.GetLvlTitleText(txt[0].text);
        //text = playerUpgHandler.GetValueText();
        //text = playerUpgHandler.GetLvlCostText();
        //text = playerUpgHandler.GetCurrentGoldText();
    }


    public void UpdateCritStatsUI()
    {
        //critLvlTitleTxt.text = playerUpgHandler.GetLvlTitleText(UpgType.Critical);
        //critValueTxt.text = playerUpgHandler.GetValueText();
        //critLvlUpTxt.text = playerUpgHandler.GetLvlCostText();
        //currentGoldTxt.text = playerUpgHandler.GetCurrentGoldText();
    }
    public void UpdateAutoAtkStateUI()
    {
        //autoAtkSpdCntTxt.text = 
        //autoAtkSpdTxt.text = 
        //autoAtkSpdCostTxt.text = 
        //autoAtkSpdCurrentTxt.text = 
    }
    public void UpdateGoldBonusStatsUI()
    {
        //goldBonusCntTxt.text = 
        //goldBonusTxt.text = 
        //goldBonusCostTxt.text = 
        //goldBonusCurrentTxt.text = 
    }
}
