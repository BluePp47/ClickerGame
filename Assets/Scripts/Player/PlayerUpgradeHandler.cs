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

    public string GetLvlTitleText(string level)
    {
        int lvl = int.Parse(level);
        lvl++;
        return lvl.ToString();
    }
    public string GetValueText(string level, UpgType type)
    {
        float value = 0f;

        switch (type)
        {
            case UpgType.Critical:
                value = data.GetCriticalValue(level);
                return ($"{value}%");
            case UpgType.AutoAttack:
                value = data.GetAutoAtkValue(level);
                return ($"{value}È¸/ÃÊ");
            case UpgType.GoldBonus:
                value = data.GetGoldBonusValue(level);
                return ($"{value}%");
        }
        return value.ToString("N1");
    }
    public string GetLvlCostText(string level)
    {
        int cost = data.GetCostValue(level);
        return cost.ToString();
    }
    public string GetCurrentGoldText(string level, int Gold)
    {
        int costGrowthPerLvl = 10;

        int lvl = int.Parse(level);
        int cost = lvl * costGrowthPerLvl;
        int value = Gold - cost;
        return value.ToString();
    }
    public void CanUpgrade()
    {
        // currentGold >= cost

    }
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}