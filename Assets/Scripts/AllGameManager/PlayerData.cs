using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Json으로 저장 및 불러오기 할 수 있도록 하기 위해
public class PlayerData
{
    public int gold;
    public int stage; //현재 플레이어의 게임진행 단계
    public int attack;
    public int level;

    public PlayerData()
    {
        gold = 0;
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
