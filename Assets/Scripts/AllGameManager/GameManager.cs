
using System;
using System.Collections;
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
    public GameObject optionPanel; //bgm이나 설정
    #region Subject
    public event Action OnCriticalUpg;
    public event Action OnAutoAtkSpdUpg;
    public event Action OnGoldBonusUpg;
    public event Action<List<TMP_Text>, UpgType> OnTestUpg;
    public void ClickCriticalUpg() => OnCriticalUpg?.Invoke();
    public void ClickAutoAtkSpdUpg() => OnAutoAtkSpdUpg?.Invoke();
    public void ClickGoldBonusUpg() => OnGoldBonusUpg?.Invoke();
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData(); //
            //currencyManager = new CurrencyManager(playerData,goldText, this);
            audioManager = FindObjectOfType<AudioManager>();
        }
        else Destroy(gameObject);
    }

    public void ToggleOptionPanel()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
    }


    public void GainGold(int amount)
    {
        currencyManager.AddGold(amount);
    }

    public void ConsumeGold(int amount)
    {
        currencyManager.SubtractGold(amount);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
