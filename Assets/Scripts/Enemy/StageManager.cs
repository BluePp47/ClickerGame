using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 게임의 전체 스테이지를 관리하는 매니저
public class StageManager : MonoBehaviour
{
    [Header("StageData (ScriptableObject)")]
    public List<StageData> stages; // 전체 스테이지 목록

    public TextMeshProUGUI stageText; // 현재 스테이지 표시용 텍스트
    public TextMeshProUGUI timerText; // 남은 시간 표시용 텍스트

    private int currentStageIndex = 0; // 현재 스테이지 인덱스
    public StageData currentStage;     // 현재 진행 중인 스테이지 정보

    private float timeRemaining; // 남은 시간
    private int enemyKill = 0;   // 현재 스테이지에서 처치한 적 수

    void Start()
    {
        LoadStage(currentStageIndex); // 게임 시작 시 첫 스테이지 로드
    }

    void Update()
    {
        if (currentStage == null) return;

        // 시간 감소 처리
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // 시간 종료 후 처리
            if (enemyKill >= currentStage.killsToNext)
            {
                NextStage(); // 조건 충족 시 다음 스테이지로 이동
            }
            else
            {
                RetryStage(); // 실패 시 스테이지 다시 시작
            }
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        if (stageText != null)
            stageText.text = $"스테이지: {currentStageIndex + 1}";

        if (timerText != null)
            timerText.text = $" {Mathf.CeilToInt(timeRemaining)}";
       
    }

    // 적 처치 시 호출됨
    public void OnEnemyKilled()
    {
        enemyKill++;

        // 목표 처치 수 도달 시 즉시 다음 스테이지
        if (enemyKill >= currentStage.killsToNext)
        {
            NextStage();
        }
    }

    // 스테이지 데이터 로드
    void LoadStage(int index)
    {
        currentStage = stages[index];
        timeRemaining = currentStage.stageDuration;
        enemyKill = 0;
    }

    // 다음 스테이지로 전환
    void NextStage()
    {
        currentStageIndex++;
        if (currentStageIndex < stages.Count)
        {
            LoadStage(currentStageIndex);
        }
        else
        {
            Debug.Log("모든 스테이지 완료!");
        }
    }

    // 현재 스테이지 다시 시작
    void RetryStage()
    {
        LoadStage(currentStageIndex);
    }
}
