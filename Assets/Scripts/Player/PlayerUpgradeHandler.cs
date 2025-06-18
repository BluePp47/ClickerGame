using UnityEngine;

public class PlayerUpgradeHandler
{
    private PlayerStatsSO data;

    private int critLevel = 0;
    private int autoAtkLevel = 0;
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
                critLevel = int.Parse(level); // refactor
                return value.ToString("N0");
            case UpgType.AutoAttack:
                value = data.GetAutoAtkValue(level);
                autoAtkLevel = int.Parse(level); // refactor
                return value.ToString("N1");
            case UpgType.GoldBonus:
                value = data.GetGoldBonusValue(level);
                return value.ToString("N0");
        }
        return value.ToString("N1");
    }
    public string GetCostText(string level)
    {
        int cost = data.GetCostValue(level);
        return cost.ToString();
    }
    public int GetCurrentGoldText(string level, int gold)
    {
        int costGrowthPerLvl = 10;

        int lvl = int.Parse(level);
        int cost = lvl * costGrowthPerLvl;
        if (gold <= cost)
        {
            return gold;
        }
        int value = gold - cost;
        return value;
    }
    public float GetCriticalValue()
    {
        return data.GetCriticalValue(critLevel.ToString());
    }
    public float GetAutoAtkValue()
    {//0이면 동작안하게 
        return data.GetAutoAtkValue(autoAtkLevel.ToString());
    }
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}