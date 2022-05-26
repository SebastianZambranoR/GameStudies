using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : Singleton<InGameUIManager>
{
    [SerializeField] private Text cashDisplay;

    [SerializeField] private Text deptDisplay;

    [SerializeField] private Text currentDay;

    [SerializeField] private Text remainDays;

    [SerializeField] private CryptoHolders[] holders;
    // Start is called before the first frame update
    

    void Start()
    {
        EconomyManager.Instance.OnCashChange += UpdateCash;
        EconomyManager.Instance.OnDebtChange += UpdateDept;
        EconomyManager.Instance.OnDayChange += UpdateDays;
    }

    private void UpdateCash(int amout)
    {
        cashDisplay.text = "Dinero: " + amout.ToString();
    }

    private void UpdateDept(int amount)
    {
        deptDisplay.text = "Deuda: " + amount.ToString();
    }

    private void UpdateDays(int current)
    {
        currentDay.text = "Dia actual: " + current.ToString();
        remainDays.text = "Restantes: " + (30 - current).ToString();
    }

    public void UpdateHolder(int holderPosition,string cryptoName, int playerAmount, int price)
    {
        holders[holderPosition].AsigneValues(cryptoName,price,playerAmount);
    }
}
