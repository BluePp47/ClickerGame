using UnityEngine;

public class PlayerUpgradeHandler
{
    private PlayerStatsSO data;


    public string GetLvlTitleText(string lvl)
    {
        int level = int.Parse(lvl);
        level++;    
        return level.ToString();
    }
    public string GetValueText(string lvl)
    {
        int level = int.Parse(lvl);
        float value = data.GetCriticalValue(level);
        return value.ToString("F1");
    }
    public string GetLvlCostText(string lvl)
    {
        int level = int.Parse(lvl);

        return level.ToString();
    }
    public string GetCurrentGoldText(string lvl)
    {
        int level = int.Parse(lvl);

        return level.ToString();
    }
}