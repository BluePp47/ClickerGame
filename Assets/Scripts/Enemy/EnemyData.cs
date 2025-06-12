using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Enemy Data",order = 1)]
public class EnemyData : ScriptableObject
{
    public string enemyName; // 이름
    public int enemyHealth; // 적 체력
    public Sprite enemySprite; // 적 스프라이트 
    public int bossHealth; // 보스 체력
    public int gold; // 처치 시 획득 골드
    
    public int GetHealthForStage(int stage)
    {
        return enemyHealth * stage; // 스테이지에 따라 체력 증가
    }
    public int GetGoldForStage(int stage)
    {
        return gold * stage; // 스테이지에 따라 골드 증가
    }
}
