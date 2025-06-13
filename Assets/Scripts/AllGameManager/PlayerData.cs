using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Json���� ���� �� �ҷ����� �� �� �ֵ��� �ϱ� ����
public class PlayerData
{
    public int gold;
    public int stage; //���� �÷��̾��� �������� �ܰ�
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
