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
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnCashChange += UpdateCash;
        EconomyManager.Instance.OnDebtChange += UpdateDept;
        EconomyManager.Instance.OnDayChange += UpdateDays;
    }

    private void UpdateCash(int amout)
    {
        cashDisplay.text = amout.ToString();
    }

    private void UpdateDept(int amount)
    {
        deptDisplay.text = amount.ToString();
    }

    private void UpdateDays(int current)
    {
        currentDay.text = current.ToString();
        remainDays.text = (30 - current).ToString();
    }
}
