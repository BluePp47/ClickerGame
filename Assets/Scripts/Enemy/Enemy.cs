using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;  // 에디터에서 할당

    private int currentHealth;

    void Start()
    {
        // 현재 스테이지 번호 가져오기 (StageManager에서)
        StageManager stageManager = FindObjectOfType<StageManager>();
        int currentStageNumber = stageManager != null ? stageManager.currentStage.stageNumber : 1;

        // 스테이지에 맞게 체력 세팅
        currentHealth = enemyData.GetHealthForStage(currentStageNumber);
    }
}
