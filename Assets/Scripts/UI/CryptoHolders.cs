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
        if (cryptoPrice > EconomyManager.Instance.CurrentPlayerCash && PlayerInventory.Instance.GetAmount(cryptoName) < 1)
        {
            selecCrypto.interactable = false;
            cryptoNameDisplay.color = selecCrypto.colors.disabledColor;
            cryptoPriceDisplay.color = selecCrypto.colors.disabledColor;
        }
        else
        {
            selecCrypto.interactable = true;
            cryptoNameDisplay.color = Color.black;
            cryptoPriceDisplay.color = Color.black;
        }
    }

    public void TradeActive()
    {
        if (PlayerInventory.Instance.GetAmount(cryptoNameDisplay.text) > 0)
        {
            if (EconomyManager.Instance.CurrentPlayerCash >= int.Parse(cryptoPriceDisplay.text))
            {
                BuyAndSellManager.Instance.ShowBuyOrSellPanel(cryptoNameDisplay.text, int.Parse(cryptoPriceDisplay.text));
            }
            else
            {
                BuyAndSellManager.Instance.ShowBuyOrSellPanel(cryptoNameDisplay.text, int.Parse(cryptoPriceDisplay.text));
                BuyAndSellManager.Instance.ShowSellPanel();
            }
        }
        else
        {
            BuyAndSellManager.Instance.ShowBuyOrSellPanel(cryptoNameDisplay.text, int.Parse(cryptoPriceDisplay.text));
            BuyAndSellManager.Instance.ShowBuyPanel();

        }

    }
    
    
}
