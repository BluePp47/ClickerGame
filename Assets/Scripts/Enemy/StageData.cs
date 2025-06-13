using System.Collections.Generic;
using UnityEngine;

// 스테이지 정보를 담는 ScriptableObject
[CreateAssetMenu(fileName = "StageData", menuName = "Stage/Stage Data")]
public class StageData : ScriptableObject
{
    public int stageNumber; // 스테이지 번호 (0부터 시작)
    public float stageDuration = 90f; // 해당 스테이지의 제한 시간
    public int killsToNext = 5; // 다음 스테이지로 넘어가기 위한 처치 수

    [Header("Possible Enemies in this stage")]
    public List<EnemyData> spawnableEnemies; // 이 스테이지에서 등장 가능한 적 목록
}
