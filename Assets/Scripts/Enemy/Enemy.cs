using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;     // 이 적이 어떤 종류인지에 대한 데이터
    public int currentHealth;       // 현재 체력

    // 외부에서 초기화할 수 있도록 Init 메서드 제공
    public void Init(EnemyData data, int stageNumber)
    {
        enemyData = data;
        currentHealth = enemyData.GetHealthForStage(stageNumber);
    }

    void Update()
    {
        // 테스트용: Q 키를 누르면 체력을 모두 잃고 사망 처리
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(currentHealth);
        }
    }

    // 데미지를 받을 때 호출
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 사망 처리
    void Die()
    {
        // 적 처치 알림
        StageManager stageManager = FindObjectOfType<StageManager>();
        if (stageManager != null)
        {
            stageManager.OnEnemyKilled();
        }

        // 적 비활성화
        gameObject.SetActive(false);

        // 1초 뒤에 새로운 적 생성 요청
        SpawnEnemy spawner = FindObjectOfType<SpawnEnemy>();
        if (spawner != null)
        {
            spawner.StartCoroutine(spawner.SpawnAfterDelay(1f, gameObject));
        }
    }
}
