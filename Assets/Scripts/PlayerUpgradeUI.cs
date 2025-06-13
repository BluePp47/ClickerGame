using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeUI : MonoBehaviour
{
    // PlayerUpg Observer

    // 추후 리팩토링
    [Header("Critical")]
    [SerializeField] private TMP_Text critUpgCntTxt;
    [SerializeField] private TMP_Text critTxt;
    [SerializeField] private TMP_Text critCostTxt;
    [SerializeField] private TMP_Text critCurrentTxt;
    [Header("AutoAtkSpd")]
    [SerializeField] private TMP_Text autoAtkSpdCntTxt;
    [SerializeField] private TMP_Text autoAtkSpdTxt;
    [SerializeField] private TMP_Text autoAtkSpdCostTxt;
    [SerializeField] private TMP_Text autoAtkSpdCurrentTxt;
    [Header("GoldBonus")]
    [SerializeField] private TMP_Text goldBonusCntTxt;
    [SerializeField] private TMP_Text goldBonusTxt;
    [SerializeField] private TMP_Text goldBonusCostTxt;
    [SerializeField] private TMP_Text goldBonusCurrentTxt;

    private void OnEnable()
    {
        GameManager.Instance.OnCriticalUpg += UpdateCritStats;
        GameManager.Instance.OnAutoAtkSpdUpg += UpdateAutoAtkSpdState;
        GameManager.Instance.OnGoldBonusUpg += UpdateGoldBonusStats;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCriticalUpg -= UpdateCritStats;
        GameManager.Instance.OnAutoAtkSpdUpg -= UpdateAutoAtkSpdState;
        GameManager.Instance.OnGoldBonusUpg -= UpdateGoldBonusStats;
    }

    public void UpdateCritStats()
    {
        //critUpgCntTxt.text =
        //critTxt.text = 
        //critCostTxt.text =
        //critCurrentTxt.text =
    }
    public void UpdateAutoAtkSpdState()
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
