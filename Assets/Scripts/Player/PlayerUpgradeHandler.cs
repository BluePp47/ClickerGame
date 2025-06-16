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

    //public string GetCurrentGoldText(string lvl)
    //{
    //    // 버튼이 눌리면 코스트만큼 현재 골드 차감
    //    // value = currentGold - cost
    //    // return value

    //    int level = int.Parse(lvl);
    //    return level.ToString();
    //}
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
    // 소지금액이 먼저 깎이고 cost가 증가해야함
    // cost == 10
    // currentGold -10
    // cost == 20
    //public string GetLvlCostText(string lvl)
    //{
    //    // cost += 10
    //    // 버튼이 눌리면 코스트 +10 씩 증가

    //    int level = int.Parse(lvl);
    //    return level.ToString();
    //}
    public PlayerUpgradeHandler(PlayerStatsSO statsdata)
    {
        data = statsdata;
    }
}