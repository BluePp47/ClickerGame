using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager 
{
    private PlayerData playerData;

    public CurrencyManager(PlayerData data)
    {
        playerData = data;
    }

    public void AddGold(int amount)
    {
        playerData.gold += amount;
    }

    public bool SubtractGold(int amount)
    {
        if (playerData.gold >= amount)
        {
            playerData.gold -= amount;
            return true;
        }
        return false;
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
