using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData; //플레이어 데이터 클래스 필요
    public AudioManager audioManager;//BGM 재생용
    private CurrencyManager currencyManager; //골드획득이나 소비용

    private void Awake()
    {
        if (Instance == null)//싱글톤
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData(); //플레이어 데이터 인스턴스 생성
            currencyManager = new CurrencyManager(playerData); // CurrencyManager 생성, PlayerData필요
            audioManager = FindObjectOfType<AudioManager>();// 씬에 있는 AudioManager 찾기
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
