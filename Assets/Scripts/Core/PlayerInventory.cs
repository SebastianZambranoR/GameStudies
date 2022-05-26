using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    private List<CryptoStruct> inventory = new List<CryptoStruct>();


    public void AddCrypto(CryptoStruct crypto)
    {
        inventory.Add(crypto);
    }

    public void RemoveCrypto(string crypto)
    {
        Debug.Log(crypto);
        for (int i = inventory.Count-1; i == 0; i--)
        {
            if (inventory[i].Name == crypto)
            {
                inventory.Remove(inventory[i]);
                break;
            }
        }
    }

    public int GetAmount(string cryptoName)
    {
        int amount = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Name == cryptoName)
                amount++;
        }

        return amount;
    }

}
