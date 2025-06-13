using System.Collections.Generic;
using UnityEngine;

// 적을 수동으로 생성하는 스크립트 (적이 죽을 때마다 호출됨)
public class SpawnEnemy : MonoBehaviour
{
    public StageManager stageManager;    // 스테이지 정보를 가져오기 위한 참조
    public GameObject enemyPrefab;       // 생성할 적 프리팹 (Enemy 스크립트 포함)
    public Transform spawnPoint;         // 적이 생성될 위치

    void Start()
    {
        // stageManager가 연결 안 됐으면 자동으로 씬에서 찾음
        if (stageManager == null)
        {
            stageManager = FindObjectOfType<StageManager>();
        }

        // 시작 시 첫 적 1마리만 생성
        SpawnOneEnemyImmediately();
    }

    // 적 하나를 즉시 생성하는 메서드 (적이 죽을 때마다 호출됨)
    public void SpawnOneEnemyImmediately()
    {
        if (stageManager.currentStage == null) return;

        List<EnemyData> spawnable = stageManager.currentStage.spawnableEnemies;

        if (spawnable == null || spawnable.Count == 0)
        {
            Debug.LogWarning("스폰 가능한 적이 없습니다!");
            return;
        }

        // 현재 스테이지에서 랜덤한 적 데이터 선택
        EnemyData selectedEnemyData = spawnable[Random.Range(0, spawnable.Count)];

        // 적 프리팹 생성
        GameObject enemyGO = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Enemy 스크립트에 적 데이터 연결
        Enemy enemyScript = enemyGO.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.enemyData = selectedEnemyData;
        }
    }
}
