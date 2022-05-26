using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BankManager : Singleton<BankManager>
{
    public int playerDeposit;

    [SerializeField] private GameObject backGround;
    [SerializeField] private GameObject centralPanel;
    [SerializeField] private GameObject depositPanel;
    [SerializeField] private Text currentDeposit;
    [SerializeField] private InputField depositAmount;
    [SerializeField] private GameObject withdrawPanel;
    [SerializeField] private Text currentDepositWithdraw;
    [SerializeField] private InputField withdrawAmount;

    [SerializeField] private Button payDept;
    [SerializeField] private Button deposit;
    [SerializeField] private Button withdraw;


    private int dayCounter;
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnDayChange += UpdateUIButtons;
        EconomyManager.Instance.OnDayChange += CountingDays;
    }

    void CountingDays(int days)
    {
        dayCounter--;

        if (dayCounter < 0)
            dayCounter = 0;
    }
    void UpdateUIButtons(int days)
    {
        if (EconomyManager.Instance.CurrentPlayerDebt == 0)
        { 
            payDept.interactable = false;
        }
        else
        {
            payDept.interactable = true;
        }

        if (playerDeposit == 0 || dayCounter > 0)
        {
            withdraw.interactable = false;
        }
        else
        {
            withdraw.interactable = true;
        }

        if (EconomyManager.Instance.CurrentPlayerCash == 0)
        {
            deposit.interactable = false;
        }
        else
        {
            deposit.interactable = true;
        }
        
    }

    public void ShowBankPanel()
    {
        UpdateUIButtons(0);
        backGround.SetActive(true);
        centralPanel.SetActive(true);
    }

    public void ShowDepositPanel()
    {
        centralPanel.SetActive(false);
        depositPanel.SetActive(true);
        currentDeposit.text = playerDeposit.ToString();
    }

    public void ShowWithdrawPanel()
    {
        centralPanel.SetActive(false);
        withdrawPanel.SetActive(true);
        currentDepositWithdraw.text = playerDeposit.ToString();
    }
    
    
    public void PayDept()
    {
        EconomyManager.Instance.ModifyPlayerCash(-EconomyManager.Instance.CurrentPlayerDebt);
        EconomyManager.Instance.ModifyPlayerDept(-EconomyManager.Instance.CurrentPlayerDebt);
        UpdateUIButtons(0);
        CloseWindows();
    }

    public void Deposit()
    {
        if (depositAmount.text != "")
        {
            playerDeposit += int.Parse(depositAmount.text);
            EconomyManager.Instance.ModifyPlayerCash(-int.Parse(depositAmount.text));
            UpdateUIButtons(0);
            dayCounter = 2;
            CloseWindows();
        }

    }

    public void CheckDepositData()
    {
        if (depositAmount.text != "")
        {
            if (int.Parse(depositAmount.text) > EconomyManager.Instance.CurrentPlayerCash)
            {
                depositAmount.text = EconomyManager.Instance.CurrentPlayerCash.ToString();
            }
        }

    }

    public void Withdraw()
    {
        if (withdrawAmount.text != "")
        {
            playerDeposit -= int.Parse(withdrawAmount.text);
            EconomyManager.Instance.ModifyPlayerCash(int.Parse(withdrawAmount.text));
            UpdateUIButtons(0);
            CloseWindows();
        }

    }
    
    public void CheckWithdrawData()
    {
        if (withdrawAmount.text != "")
        {
            if (int.Parse(withdrawAmount.text) > playerDeposit)
            {
                withdrawAmount.text = playerDeposit.ToString();
            }
        }

    }

    public void CloseWindows()
    {
        backGround.SetActive(false);
        centralPanel.SetActive(false);
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }
}
