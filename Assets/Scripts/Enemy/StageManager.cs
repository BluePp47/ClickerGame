using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public float stageTime = 90f; // 스테이지 시간 
    public float timeReamaing; // 남은 시간
    public int currentStage = 1; // 현재 스테이지
    public int bossStage = 50; // 보스 스테이지

    public int enemykilled = 0; // 처치한 적 수에 따라 스테이지를 올리는 방식을 생각중 !
    public int killedForNextStage = 5; // 다음 스테이지로 넘어가기 위한 적 처치 수

    EnemyData enemyData; // 적 데이터 스크립트

    public void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeReamaing > 0)
        {
            timeReamaing -= Time.deltaTime; // 남은 시간 감소
        }
        else
        {
            ResetStage(); // 시간이 다 되면 다음 스테이지로 넘어감
        }
    }
    public void ResetStage()
    {
        if (timeReamaing <= 0)
        {
            timeReamaing = 90;
            enemykilled = 0; // 적 처치 수 초기화
           //enemycs에 currenthp 를 저장하고 그 걸 초기화 해야함 ! 
           //data를 건들면 모든게 망가질 수 있다 

        }
    }
}
