using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EconomyManager : Singleton<EconomyManager>
{
    private int currentPlayerCash = 0;
    private int currentPlayerDebt = 0;
    private int currentDay;
    


    /*Este script se encarga del control general de la economia, donde se tienen en cuenta:
     * El dinero del jugador
     * La deuda con el banco
     * Los dias que van y los que faltan
     * El cambio de dia a dia
     */
    [Header("SetUp")]
    [SerializeField] private int startinPlayerCash;

    [SerializeField] private int startingPlayerDebt;
    
    [SerializeField] private int dailyTaxes;
    
    private CryptoPriceChanger priceChanger;
    
    public int CurrentDay => currentDay;

    public int CurrentPlayerCash => currentPlayerCash;

    public int CurrentPlayerDebt => currentPlayerDebt;


    public Action<int> OnDayChange;
    public Action<int> OnDebtChange;
    public Action<int> OnCashChange;

    public Action OnFinishGame;
    // Start is called before the first frame update
    void Start()
    {
        priceChanger = GetComponent<CryptoPriceChanger>();
        StartGame();
    }

    void StartGame()
    {
        InGameUIManager.Instance.Initialize();
        priceChanger.Initialize();
        currentDay = 1;

        currentPlayerCash = startinPlayerCash;
        currentPlayerDebt = startingPlayerDebt;
        OnCashChange?.Invoke(currentPlayerCash);
        OnDebtChange?.Invoke(currentPlayerDebt);
        OnDayChange?.Invoke(currentDay);
        UpdateCryptoHolders();
    }

    public void UpdateCryptoHolders()
    {
        for (int i = 0; i < priceChanger.cryptos.Length; i++)
        {
            InGameUIManager.Instance.UpdateHolder(i,priceChanger.cryptos[i].Name,PlayerInventory.Instance.GetAmount(priceChanger.cryptos[i].Name),
                priceChanger.cryptos[i].currentPrice);
        }
    }

    public CryptoStruct GetRandomCrypto()
    {
        int rand = UnityEngine.Random.Range(0, 8);
        return priceChanger.cryptos[rand];
    }

    public void ModifyPlayerCash(int amount)
    {
        currentPlayerCash += amount;
        OnCashChange?.Invoke(currentPlayerCash);
    }

    public void ModifyPlayerDept(int amount)
    {
        currentPlayerDebt += amount;
        OnDebtChange?.Invoke(currentPlayerDebt);
    }

    public void PastDay()
    {
        currentDay++;
        OnDayChange?.Invoke(currentDay);
        if (currentPlayerDebt > 0)
        {
            ModifyPlayerDept((currentPlayerDebt * dailyTaxes) / 100);
        }
        UpdateCryptoHolders();

        if (currentDay > 30)
        {
            OnFinishGame?.Invoke();
        }
    }

    public int GetPlayerAmountCapacity(int price)
    {
        float amount = (float)currentPlayerCash / price;
        return Mathf.FloorToInt(amount);
    }

    public void NewsEffets(CryptoStruct crypto)
    {
        priceChanger.NewsCryptoValueChange(crypto);
        UpdateCryptoHolders();
    }

    public int GetPlayerTotal()
    {
        return currentPlayerCash + BankManager.Instance.playerDeposit - currentPlayerDebt;
    }
}
