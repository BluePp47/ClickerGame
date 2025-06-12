using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatCalculator
{

    public static int CalculateAttack(PlayerData data)
    {
        return data.level * 2 + data.attack;
    }

    public static int CalculateNextLevelCost(PlayerData data)
    {
        return data.level * 100;
    }
}
