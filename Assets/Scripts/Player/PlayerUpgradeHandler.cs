using UnityEngine;

public class PlayerUpgradeHandler : MonoBehaviour
{
    int sumCritLvl = 1;
    public string GetLvlTitleText(string lvl)
    {
        int level = int.Parse(lvl);
        level++;
        return level.ToString();
    }
    //public string GetLvlTitleText(UpgType type)
    //{
    //    //Ű ���� �ް� Ű ���� �°� ���� ó��
    //    // key == critical�̸�
    //    int result;

    //    // ��ư�� ������ ��ų������ ���Ǿ���
    //    switch (type)
    //    {
    //        case UpgType.Critical:
    //            {
    //                sumCritLvl++;
    //                result = sumCritLvl;
    //                return result.ToString();
    //            }
    //        //case UpgType.AutoAtk:
    //        //    {
    //        //        return autoAtk.ToString();
    //        //    }
    //        //case UpgType.GoldBonus:
    //        //    {
    //        //        return GoldBonus.ToString();
    //        //    }
    //    }
        
    //    return "a";
    //}

    //public string GetValueText()
    //{
    //    float crit, autoAtk, GoldBonus;
    //    return a;
    //}

    //public string GetLvlCostText()
    //{
    //    int crit, autoAtk, GoldBonus;
    //    return a;
    //}

    //public string GetCurrentGoldText()
    //{
    //    int crit, autoAtk, GoldBonus;
    //    return a;
    //}
}
