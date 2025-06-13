using UnityEngine;

// 각 적의 기본 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    public string enemyName;       // 적 이름
    public int enemyHealth;        // 기본 체력
    public int bossHealth;         // 보스 체력 (보스가 있다면)
    public Sprite enemySprite;     // 적 이미지
    public int gold;               // 처치 시 획득 골드

    // 스테이지에 따라 체력 증가
    public int GetHealthForStage(int stage)
    {
        return enemyHealth * stage;
    }

    // 스테이지에 따라 골드 증가
    public int GetGoldForStage(int stage)
    {
        return gold * stage;
    }
}
