using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager 
{
    private PlayerData playerData;
    private Text goldText; //UGUI �ؽ�Ʈ�� ���ǥ��
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
        int startValue = int.Parse(goldText.text); //���� �� ���� �ؽ�Ʈ�� ǥ�õ� ��� ���� �ݿ�

        int endValue = playerData.gold; //�������� ���� ������ ��ȭ

        float waitTime = 0.02f; //���ڸ� ������ �� �ɸ��� �ð�

        //��尡 �������� �������� Ȯ��
        if (startValue < endValue) //�������
        {
            
            for (int i = startValue; i <= endValue; i++)//for������ ���ڸ� 1 �� ��ȭ, ���� ���̴� ȿ��
            {
                goldText.text = i.ToString(); // �ؽ�Ʈ UI ������Ʈ
                yield return new WaitForSeconds(waitTime); // ���
            }
        }
        else
        {
            for (int i = startValue; i >= endValue; i--)// ��尡 ������ ��
            {
                goldText.text = i.ToString(); // �ؽ�Ʈ UI ������Ʈ
                yield return new WaitForSeconds(waitTime); // ���
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
