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
    public string GetValueText(string lvl)
    {
        float value = data.GetCriticalValue(lvl);
        return value.ToString("F1");
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