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
    [SerializeField] private TMP_Text critValueTitleTxt;
    [SerializeField] private TMP_Text critValueTxt;
    [Header("AutoAtk")]
    [SerializeField] private TMP_Text autoAtkLvlTitleTxt;
    [SerializeField] private TMP_Text autoAtkValueTitleTxt;
    [SerializeField] private TMP_Text autoAtkValueTxt;
    [Header("GoldBonus")]
    [SerializeField] private TMP_Text goldBonusLvlTitleTxt;
    [SerializeField] private TMP_Text goldBonusValueTitleTxt;
    [SerializeField] private TMP_Text goldBonusValueTxt;

    private void OnEnable()
    {
        // GM Rename OnAutoAtkSpdUpg -> OnAutoAtkUpg
        GameManager.Instance.OnCriticalUpg += UpdateCritStats;
        GameManager.Instance.OnAutoAtkSpdUpg += UpdateAutoAtkState;
        GameManager.Instance.OnGoldBonusUpg += UpdateGoldBonusStats;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCriticalUpg -= UpdateCritStats;
        GameManager.Instance.OnAutoAtkSpdUpg -= UpdateAutoAtkState;
        GameManager.Instance.OnGoldBonusUpg -= UpdateGoldBonusStats;
    }

    public void UpdateCritStats()
    {
        critLvlTitleTxt.text =
        critValueTitleTxt.text =
        autoAtkValueTxt.text =
        critCurrentGoldTxt.text =
    }
    public void UpdateAutoAtkState()
    {
        //autoAtkSpdCntTxt.text = 
        //autoAtkSpdTxt.text = 
        //autoAtkSpdCostTxt.text = 
        //autoAtkSpdCurrentTxt.text = 
    }
    public void UpdateGoldBonusStats()
    {
        //goldBonusCntTxt.text = 
        //goldBonusTxt.text = 
        //goldBonusCostTxt.text = 
        //goldBonusCurrentTxt.text = 
    }
}
