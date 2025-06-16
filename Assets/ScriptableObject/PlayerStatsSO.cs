using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Stats")]
public class PlayerStatsSO : ScriptableObject
{
    // Upgrade Level DataTable SO
    private PlayerStatsSO data;

    private float critGrowthPerLvl = 50.0f;
    private float autoAtkPerLvl = 0.3f;
    private float goldBonusPerLvl = 100.0f;

    public float GetCriticalValue(int level)
    {
        float result = critGrowthPerLvl * level;
        return result;
    }
    public float GetAutoAtkValue(int level)
    {
        return autoAtkPerLvl * level;
    }
    public float GetGoldBonusValue(int level)
    {
        return goldBonusPerLvl * level;
    }

    public void PlayerUpgradeHandler(PlayerStatsSO stats)
    {
        data = stats;
    }

}