using UnityEngine;

public class PlayerUpgradeHandler
{
    private PlayerStatsSO data;

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

    //public string GetLvlCostText(string lvl)
    //{
    //    //float value = 
    //    //return value.ToString();
    //}
    //public string GetCurrentGoldText(string lvl)
    //{
    //    //float value = 
    //    //return value.ToString();
    //}
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}