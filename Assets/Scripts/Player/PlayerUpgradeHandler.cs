using UnityEngine;

public class PlayerUpgradeHandler
{
    private PlayerStatsSO data;

    private int currentGold;
    public int CurrentGold => currentGold;
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
                return ($"{value}»∏/√ ");
            case UpgType.GoldBonus:
                value = data.GetGoldBonusValue(level);
                return ($"{value}%");
        }
        return value.ToString("N1");
    }
    public string GetCostText(string level)
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
    //public int GetCost(UpgType type)
    //{
    //    int level = GetLevel(type);
    //    int value = data.GetCostValue((level + 1).ToString());
    //    return value;
    //}
    //public int GetLevel(UpgType type)
    //{
    //    switch (type)
    //    {
    //        case UpgType.Critical:
    //            return critLevel;
    //    }
    //}
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}