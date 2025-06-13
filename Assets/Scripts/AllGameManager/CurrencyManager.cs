using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager 
{
    private PlayerData playerData;
    private Text goldText; //UGUI 텍스트로 골드표시
    private MonoBehaviour coroutineHost;

    public CurrencyManager(PlayerData data, Text goldText, MonoBehaviour host)
    {
        this.playerData = data;
        this.goldText = goldText;
        this.coroutineHost = host;

        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        playerData.gold += amount;
        coroutineHost.StartCoroutine(GoldChange());
    }

    public bool SubtractGold(int amount)
    {
        if (playerData.gold >= amount)
        {
            playerData.gold -= amount;
            coroutineHost.StartCoroutine(GoldChange());
            return true;
        }
        return false;
    }
    private void UpdateGoldUI()
    {
        goldText.text = $"Gold: {playerData.gold}";
    }

    private IEnumerator GoldChange()
    {
        int startValue = int.Parse(goldText.text); //시작 시 현재 텍스트에 표시된 골드 값을 반영

        int endValue = playerData.gold; //끝났을때 실제 보유한 재화

        float waitTime = 0.02f; //숫자를 변경할 때 걸리는 시간

        //골드가 증가인지 감소인지 확인
        if (startValue < endValue) //골드증가
        {
            
            for (int i = startValue; i <= endValue; i++)//for문으로 숫자를 1 씩 변화, 눈에 보이는 효과
            {
                goldText.text = i.ToString(); // 텍스트 UI 업데이트
                yield return new WaitForSeconds(waitTime); // 대기
            }
        }
        else
        {
            for (int i = startValue; i >= endValue; i--)// 골드가 감소할 때
            {
                goldText.text = i.ToString(); // 텍스트 UI 업데이트
                yield return new WaitForSeconds(waitTime); // 대기
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
