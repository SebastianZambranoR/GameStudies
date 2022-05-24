using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSellManager : Singleton<BuyAndSellManager>
{
    [SerializeField] private GameObject buyAndSellPanel;

    [SerializeField] private Button buyButton;

    [SerializeField] private Button sellButton;

    [SerializeField] private Text amountDisplay;

    [SerializeField] private Slider amountSlider;

    [SerializeField] private Text displayText;

    
    // Start is called before the first frame update
    void Start()
    {
        buyAndSellPanel.SetActive(false);
    }

    public void ShowPanel(string cryptoName, int cryptoPrice, int maxAmount)
    {
        displayText.text = cryptoName + " " + cryptoPrice;
        ChangeAmountValue(maxAmount);
        amountSlider.maxValue = maxAmount;
        amountSlider.minValue = 1;
        amountSlider.value = maxAmount;
    }

    public void ChangeAmountValue(int amount)
    {
        amountDisplay.text = amount.ToString();
    }
}
