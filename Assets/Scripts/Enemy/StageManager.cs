using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("StageData (ScriptableObject)")]
    public List<StageData> stages;

    private int currentStageIndex = 0; 
    public StageData currentStage;

    private float timeRemaining;
    private int enemyKill = 0;

    void Start()
    {
        LoadStage(currentStageIndex);
    }

    void Update()
    {
        if (currentStage == null) return;

        // 시간 감소
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // 시간이 다 되었을 때 조건 분기
            if (enemyKill >= currentStage.killsToNext)
            {
                // 다 죽였다면 다음 스테이지
                NextStage();
            }
            else
            {
                // 못 죽였다면 현재 스테이지 반복
                RetryStage();
            }
        }
    }

    public void OnEnemyKilled()
    {
        enemyKill++;

        if (enemyKill >= currentStage.killsToNext)
        {
            // 적을 다 죽이면 즉시 다음 스테이지로 넘어감
            NextStage();
        }
    }

    void LoadStage(int index)
    {
        currentStage = stages[index];
        timeRemaining = currentStage.stageDuration;
        enemyKill = 0;  
    }

    void NextStage()
    {
        currentStageIndex++;
        LoadStage(currentStageIndex);
    }

    void RetryStage()
    {
        
        LoadStage(currentStageIndex); // 현재 스테이지 다시 시작
    }
}
