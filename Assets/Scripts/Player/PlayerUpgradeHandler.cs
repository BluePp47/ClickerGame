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
    //    int level = int.Parse(lvl);

    //    return level.ToString();
    //}
    //public string GetCurrentGoldText(string lvl)
    //{
    //    int level = int.Parse(lvl);

    //    return level.ToString();
    //}
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}