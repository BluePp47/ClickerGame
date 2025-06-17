using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public StageManager stageManager;    // 스테이지 정보를 가져오기 위한 참조
    public Transform spawnPoint;         // 적이 생성될 위치

    public Attack attack;
    void Start()
    {
        // stageManager가 연결 안 됐으면 자동으로 씬에서 찾음
        if (stageManager == null)
        {
            stageManager = FindObjectOfType<StageManager>();
        }

        // 시작 시 첫 적 1마리 생성
        SpawnOneEnemyImmediately();
    }

    // 적 하나를 즉시 생성하는 메서드 (적이 죽을 때 호출됨)
    public void SpawnOneEnemyImmediately()
    {
        // 스테이지 정보가 없으면 생성하지 않음
        if (stageManager.currentStage == null) return;

        // 생성 가능한 적 리스트 가져오기
        List<EnemyData> spawnable = stageManager.currentStage.spawnableEnemies;

        // 리스트가 비었으면 경고 출력 후 종료
        if (spawnable == null || spawnable.Count == 0)
        {
            return; //방코
        }

        // 랜덤한 EnemyData 선택
        EnemyData selectedEnemyData = spawnable[Random.Range(0, spawnable.Count)];

        // EnemyData에 연결된 프리팹이 없으면 방코
        if (selectedEnemyData.prefab == null)
        {
            return; //방코
        }

        // 선택한 프리팹을 해당 위치에 생성
        GameObject enemyGO = Instantiate(selectedEnemyData.prefab, transform);
        enemyGO.transform.position = spawnPoint.position;
        enemyGO.transform.rotation = Quaternion.identity;
        // spawnPoint.position, Quaternion.identity);

        // Enemy 스크립트에 데이터 전달 및 초기화
        Enemy enemyScript = enemyGO.GetComponentInChildren<Enemy>();
        if (enemyScript != null)
        {
            int stageNumber = stageManager.currentStage.stageNumber;
            enemyScript.Init(selectedEnemyData, stageNumber);
            attack.SetEnemy(enemyScript);
            
        }
        else
        {
            return; // 방코 
        }
    }

    // 일정 시간 후 적을 생성하고 기존 오브젝트 제거
    public IEnumerator SpawnAfterDelay(float delay, GameObject enemyToDestroy)
    {
        yield return new WaitForSeconds(delay);

        SpawnOneEnemyImmediately();

        // enemyToDestroy가 유효한지 확인 후 제거
        if (enemyToDestroy != null)
        {
            var root = enemyToDestroy.transform.parent;
            if (root != null && root.gameObject != null)
            {
                Destroy(root.gameObject);
            }
        }
    }
}
