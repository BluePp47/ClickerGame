using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData; //�÷��̾� ������ Ŭ���� �ʿ�
    public AudioManager audioManager;//BGM �����
    private CurrencyManager currencyManager; //���ȹ���̳� �Һ��
    #region Subject
    public event Action OnCriticalUpg;
    public event Action OnAutoAtkSpdUpg;
    public event Action OnGoldBonusUpg;
    public void ClickCriticalUpg() => OnCriticalUpg?.Invoke();
    public void ClickAutoAtkSpdUpg() => OnAutoAtkSpdUpg?.Invoke();
    public void ClickGoldBonusUpg() => OnGoldBonusUpg?.Invoke();
    #endregion
    private void Awake()
    {
        if (Instance == null)//�̱���
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            playerData = new PlayerData(); //�÷��̾� ������ �ν��Ͻ� ����
            currencyManager = new CurrencyManager(playerData); // CurrencyManager ����, PlayerData�ʿ�
            audioManager = FindObjectOfType<AudioManager>();// ���� �ִ� AudioManager ã��
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
