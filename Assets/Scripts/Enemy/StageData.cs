
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Stage/Stage Data")]
public class StageData : ScriptableObject
{
    public int stageNumber; // 스테이지 번호 (0부터 시작)
    public float stageDuration = 90f; // 스테이지 지속 시간 
    public int killsToNext = 5; // 다음 스테이지로 넘어가기 위한 적 처치 수

    [Header("Possible Enemies in this stage")]
    public List<EnemyData> spawnableEnemies;
}
