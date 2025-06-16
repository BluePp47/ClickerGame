using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Stats")]
public class PlayerStatsSO : ScriptableObject
{
    // Upgrade Level DataTable SO
    private float critGrowthPerLvl = 50.0f;
    private float autoAtkPerLvl = 0.3f;
    private float goldBonusPerLvl = 100.0f;

    public float GetCriticalValue(string level)
    {
        float lvl = float.Parse(level);
        float result = critGrowthPerLvl * (lvl);
        return result;
    }
    public float GetAutoAtkValue(int level)
    {
        float result = autoAtkPerLvl * level;
        return result;
    }
    public float GetGoldBonusValue(int level)
    {
        float result = goldBonusPerLvl * level;
        return result;
    }
}