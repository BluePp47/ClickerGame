using Unity.VisualScripting;
using UnityEngine;

// 개별 적에 붙는 스크립트
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; // 적의 데이터 (스탯 등)
    public Attack attack;

    public int currentHealth;

    void Start()
    {
        // 현재 스테이지 정보에 따라 체력 결정
        StageManager stageManager = FindObjectOfType<StageManager>();
        int currentStageNumber = stageManager != null ? stageManager.currentStage.stageNumber : 1;

        currentHealth = enemyData.GetHealthForStage(currentStageNumber);

        if (Input.GetMouseButton(0))
        {
            TakeDamage(10);
        }
    }

    // 데미지를 받는 함수
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die(); // 체력 0 이하이면 사망 처리
        }
    }

    // 적이 죽었을 때
    void Die()
    {
        // StageManager에 적 처치 알림
        StageManager stageManager = FindObjectOfType<StageManager>();
        if (stageManager != null)
        {
            stageManager.OnEnemyKilled();
        }

        // 적이 죽자마자 새 적을 소환
        SpawnEnemy spawner = FindObjectOfType<SpawnEnemy>();
        if (spawner != null)
        {
            spawner.SpawnOneEnemyImmediately();
        }

        Destroy(gameObject); // 본인 제거
    }
}
