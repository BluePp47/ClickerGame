using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable] //Json으로 저장 및 불러오기 할 수 있도록 하기 위해
public class PlayerData
{
    public int gold;
    public int stage; //현재 플레이어의 게임진행 단계
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

    public void Save()//저장
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(SavePath, json, Encoding.UTF8);
        Debug.Log("저장 완료: " + SavePath);
    }

    public void Load()//불러오기
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath, Encoding.UTF8);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("불러오기 완료");
        }
        else
        {
            Debug.Log("저장 파일 없음. 기본값 사용.");
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
