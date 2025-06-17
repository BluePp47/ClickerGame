using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData; //플레이어 데이터 클래스 필요
    public AudioManager audioManager;//BGM 재생용
    private CurrencyManager currencyManager; //골드획득이나 소비용
    public Text goldText;
    public event Action<List<TMP_Text>, UpgType> OnUpdateUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData(); //
            currencyManager = new CurrencyManager(playerData,goldText, this);
            audioManager = FindObjectOfType<AudioManager>();
        }
        else Destroy(gameObject);
    }

    public void GainGold(int amount)
    {
        currencyManager.AddGold(amount);
    }

    public void ConsumeGold(int amount)
    {
        currencyManager.SubtractGold(amount);
    }

}
