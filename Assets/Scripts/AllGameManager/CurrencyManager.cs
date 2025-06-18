using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI goldText; //UGUI 텍스트로 골드표시
    public float waitTime = 0.02f; // 텍스트가 변경되는 속도<= float waitTime = 0.02f; //숫자를 변경할 때 걸리는 시간
    public event Action<int> OnGoldChanged;
    void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        playerData.gold += amount;
        StartCoroutine(GoldChange());
        OnGoldChanged?.Invoke(playerData.gold);
    }

    public bool SubtractGold(int amount)
    {
        if (playerData.gold >= amount)
        {
            playerData.gold -= amount;
            StartCoroutine(GoldChange());
            return true;
        }
        return false;
    }
    private void UpdateGoldUI()
    {
        goldText.text = $"{playerData.gold}";
    }

    private IEnumerator GoldChange()
    {
        int startValue = int.Parse(goldText.text.Replace("Gold: ", "")); //시작 시 현재 텍스트에 표시된 골드 값을 반영

        int endValue = playerData.gold; //끝났을때 실제 보유한 재화

        

        //골드가 증가인지 감소인지 확인
        if (startValue < endValue) //골드증가
        {
            
            for (int i = startValue; i <= endValue; i++)//for문으로 숫자를 1 씩 변화, 눈에 보이는 효과
            {
                goldText.text = $"Gold: {i}"; // 텍스트 UI 업데이트
                yield return new WaitForSeconds(waitTime); // 대기
            }
        }
        else
        {
            for (int i = startValue; i >= endValue; i--)// 골드가 감소할 때 
            {
                goldText.text = $"Gold: {i}"; // 텍스트 UI 업데이트
                yield return new WaitForSeconds(waitTime); // 대기
            }
        }
    }


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
