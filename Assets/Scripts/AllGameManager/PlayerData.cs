using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable] //Json���� ���� �� �ҷ����� �� �� �ֵ��� �ϱ� ����
public class PlayerData
{
    public int gold;
    public int stage; //���� �÷��̾��� �������� �ܰ�
    public int attack;
    public float criticalChance;
    public int level;

    public List<string> ownedWeapons;
    public string equippedWeapon;
    public Dictionary<string, int> weaponEnhancementLevels;

    public int autoAttackLevel;
    public int criticalLevel;

    public Dictionary<string, int> consumableItems;
    public Dictionary<string, int> statUpgradeLevels;

    private string SavePath => Path.Combine(Application.persistentDataPath, "player_save.json");

    public void Save()//����
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(SavePath, json, Encoding.UTF8);
        Debug.Log("���� �Ϸ�: " + SavePath);
    }

    public void Load()//�ҷ�����
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath, Encoding.UTF8);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("�ҷ����� �Ϸ�");
        }
        else
        {
            Debug.Log("���� ���� ����. �⺻�� ���.");
        }
    }
    public PlayerData()
    {
        gold = 10000;
        stage = 1;
        attack = 10;
        level = 1;

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
