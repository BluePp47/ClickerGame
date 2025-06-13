using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeUI : MonoBehaviour
{
    // PlayerUpg Observer

    // 추후 리팩토링
    [SerializeField] private TMP_Text CurrentGoldTxt;
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

    private void OnEnable()
    {
        // GM Rename OnAutoAtkSpdUpg -> OnAutoAtkUpg
        GameManager.Instance.OnCriticalUpg += UpdateCritStatsUI;
        GameManager.Instance.OnAutoAtkSpdUpg += UpdateAutoAtkStateUI;
        GameManager.Instance.OnGoldBonusUpg += UpdateGoldBonusStatsUI;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCriticalUpg -= UpdateCritStatsUI;
        GameManager.Instance.OnAutoAtkSpdUpg -= UpdateAutoAtkStateUI;
        GameManager.Instance.OnGoldBonusUpg -= UpdateGoldBonusStatsUI;
    }

    public void UpdateCritStatsUI()
    {
        //critLvlTitleTxt.text =
        //critValueTxt.text = 
        //critLvlUpTxt.text =
        //critCurrentGoldTxt.text =
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
