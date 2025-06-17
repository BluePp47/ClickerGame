using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Stats")]
public class PlayerStatsSO : ScriptableObject
{
    // UpgradeGrowthPerLevel DataTable SO
    private float critGrowthPerLvl = 50.0f;
    private float autoAtkPerLvl = 0.3f;
    private float goldBonusPerLvl = 100.0f;
    private int costGrowthPerLvl = 10;

    #region ValueLogin
    public float GetCriticalValue(string level)
    {
        float lvl = float.Parse(level);
        float result = critGrowthPerLvl * lvl;
        return result;
    }
    public float GetAutoAtkValue(string level)
    {
        float lvl = float.Parse(level);
        float result = autoAtkPerLvl * lvl;
        return result;
    }
    public float GetGoldBonusValue(string level)
    {
        float lvl = float.Parse(level);
        float result = goldBonusPerLvl * lvl;
        return result;
    }
    #endregion
    public int GetCostValue(string level)
    {
        int lvl = int.Parse(level);
        int result = (lvl + 1) * costGrowthPerLvl;
        return result;
    }
}