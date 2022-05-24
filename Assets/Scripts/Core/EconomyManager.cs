using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    private int currentPlayerCash = 0;
    private int currentPlayerDebt = 0;
    
    public int CurrentDay => currentDay;

    public int CurrentPlayerCash => currentPlayerCash;

    public int CurrentPlayerDebt => currentPlayerDebt;

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



    private int currentDay;
    // Start is called before the first frame update
    void Start()
    {
        currentDay = 1;
        currentPlayerCash = startinPlayerCash;
        currentPlayerDebt = startingPlayerDebt;
    }

    public void ModifyPlayerCash(int amount)
    {
        currentPlayerCash += amount;
    }

    public void ModifyPlayerDept(int amount)
    {
        currentPlayerDebt += amount;
    }

    public void PastDay()
    {
        currentDay++;
        if (currentPlayerDebt > 0)
        {
            currentPlayerDebt += (currentPlayerDebt * dailyTaxes) / 100;
        }
    }
}
