using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData; //플레이어 데이터 클래스 필요
    public AudioManager audioManager;//BGM 재생용
    [SerializeField] private CurrencyManager currencyManager; //골드획득이나 소비용
    public TextMeshProUGUI goldText;
    public PlayerUpgradeHandler playerUpgradeHandler { get; private set; }
    [SerializeField] private PlayerStatsSO statsSO;
    public event Action<List<TMP_Text>, UpgType> OnUpdateUI;

    private float addGold;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData();
            playerData.Load();

            if (currencyManager == null)
                currencyManager = FindObjectOfType<CurrencyManager>();

            currencyManager.playerData = playerData;
            currencyManager.goldText = goldText;

            audioManager = FindObjectOfType<AudioManager>();
            playerUpgradeHandler = new PlayerUpgradeHandler(statsSO);
        }
        else Destroy(gameObject);
    }
    public void SaveGame()
    {
        playerData.Save();
    }
    void Start()
    {
        playerData.Load();
    }


    public void OnClickUpgrade(List<TMP_Text> list, UpgType type)
    {
        OnUpdateUI?.Invoke(list, type);
    }

    public void GainGold(int amount)
    {
        if (addGold > 0)
        {
            int addGoldBonus = (int)((addGold / 100) * amount);
            currencyManager.AddGold(amount + addGoldBonus);
            Debug.Log($"addGoldBonus {amount + addGoldBonus}");

        }
        else
        {
            Debug.Log($"amount {amount}");
            currencyManager.AddGold(amount);
        }
    }
    public void SetAddGold(float value)
    {
        addGold = value;
    }
    public void ConsumeGold(int amount)
    {
        currencyManager.SubtractGold(amount);
    }

}
