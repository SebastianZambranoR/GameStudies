using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptoHolders : MonoBehaviour
{
    [SerializeField] private Button selecCrypto;
    [SerializeField] private Text cryptoNameDisplay;
    [SerializeField] private Text cryptoPriceDisplay;
    [SerializeField] private Text playerAmountDisplay;
    
    
    public void AsigneValues(string cryptoName, int cryptoPrice, int playerAmount)
    {
        cryptoNameDisplay.text = cryptoName;
        cryptoPriceDisplay.text = cryptoPrice.ToString();
        playerAmountDisplay.text = playerAmount.ToString();
        selecCrypto.onClick.AddListener(TradeActive);
    }

    public void TradeActive()
    {
        BuyAndSellManager.Instance.ShowPanel(cryptoNameDisplay.text, int.Parse(cryptoPriceDisplay.text),
            EconomyManager.Instance.GetPlayerAmountCapacity(int.Parse(cryptoPriceDisplay.text)));
    }
    
    
}
