using UnityEngine;

public class PlayerUpgradeHandler
{
    private PlayerStatsSO data;

    private int critLvl = 1;
    private int autoAtkLvl = 1;
    private int goldBonusLvl = 1;
    public int CritLvl => critLvl;
    public int AutoAtkLvl => autoAtkLvl;
    public int GoldBonusLvl => goldBonusLvl;

    //test
    private int currentGold = 10000;
    private int cost = 10;

    public string GetLvlTitleText(string level)
    {
        int lvl = int.Parse(level);
        lvl++;
        return lvl.ToString();
    }
    public string GetValueText(string lvl, UpgType type)
    {
        float value = 0f;
        switch (type)
        {
            case UpgType.Critical:
                value = data.GetCriticalValue(lvl); break;
            case UpgType.AutoAttack:
                value = data.GetAutoAtkValue(lvl); break;
            case UpgType.GoldBonus:
                value = data.GetGoldBonusValue(lvl); break;
        }
        return value.ToString("N1");
    }
    public string GetLvlCostText(string lvl)
    {
        int cost = data.GetCostValue(lvl);//레벨별 cost 계산
        int value
        return value.ToString();
    }
    public string GetCurrentGoldText(string lvl)
    {
        // 버튼이 눌리면 코스트만큼 현재 골드 차감
        // value = currentGold - cost
        // return value
        // 인자로 cost를 받고 curGold값을 
        int level = int.Parse(lvl);
        int value = currentGold - cost;
        return value.ToString();
    }
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}