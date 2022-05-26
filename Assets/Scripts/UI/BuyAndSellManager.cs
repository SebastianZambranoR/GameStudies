using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSellManager : Singleton<BuyAndSellManager>
{
    [SerializeField] private GameObject backGroundPanel;
    
    [SerializeField] private GameObject buyAndSellPanel;

    [SerializeField] private Text buyAndSellText;
    
    [SerializeField] private GameObject buyPanel;
    
    [SerializeField] private GameObject sellPanel;

    [SerializeField] private Button buyButton;

    [SerializeField] private Button sellButton;

    [SerializeField] private Text buyAmountDisplay;

    [SerializeField] private Text sellAmountDisplay;

    [SerializeField] private Slider buyAmountSlider;
   
    [SerializeField] private Slider sellAmountSlider;
    
    [SerializeField] private Text buyDisplayText;
    
    [SerializeField] private Text sellDisplayText;

    [SerializeField] private Text sellPreviosValue;

    private string activeCryptoName;
    private int activeCryptoPrice;
    
    // Start is called before the first frame update
    void Start()
    {
        buyAndSellPanel.SetActive(false);
    }

    public void ShowBuyOrSellPanel(string cryptoName, int cryptoPrice)
    {
        activeCryptoName = cryptoName;
        activeCryptoPrice = cryptoPrice;
        backGroundPanel.SetActive(true);
        buyAndSellPanel.SetActive(true);
        buyAndSellText.text = cryptoName + " " + cryptoPrice;
    }

    public void ShowBuyPanel()
    {
        buyAndSellPanel.SetActive(false);
        buyPanel.SetActive(true);
        buyDisplayText.text = activeCryptoName + " " + activeCryptoPrice;
        buyAmountSlider.maxValue = EconomyManager.Instance.GetPlayerAmountCapacity(activeCryptoPrice);
        buyAmountSlider.value = buyAmountSlider.maxValue;
        ChangeAmountValue(buyAmountSlider.value);
    }
    
    public void ShowSellPanel()
    {
        buyAndSellPanel.SetActive(false);
        sellPanel.SetActive(true);
        sellDisplayText.text = activeCryptoName + " " + activeCryptoPrice;
        sellAmountSlider.maxValue = PlayerInventory.Instance.GetAmount(activeCryptoName);
        sellAmountSlider.value = sellAmountSlider.maxValue;
        ChangeAmountValue(sellAmountSlider.value);
        sellPreviosValue.text = "Comprado por: " + PlayerInventory.Instance.GetPreviousValue(activeCryptoName);
    }

    public void ChangeAmountValue(float value)
    {
        buyAmountDisplay.text = value.ToString();
        sellAmountDisplay.text = value.ToString();
    }

    public void BuyOperation()
    {
        CryptoStruct temp = CryptoStruct.CreateInstance<CryptoStruct>();
        temp.Name = activeCryptoName;
        temp.currentPrice = activeCryptoPrice;
        for (int i = 0; i < buyAmountSlider.value; i++)
        {
            PlayerInventory.Instance.AddCrypto(temp);
        }
        EconomyManager.Instance.ModifyPlayerCash(-(int)(activeCryptoPrice* buyAmountSlider.value));
        EconomyManager.Instance.UpdateCryptoHolders();
        AudioSource.PlayClipAtPoint(Audios.Instance.sonidoCompra, transform.position);
        CloseWindow();
    }

    public void SellOperation()
    {
        for (int i = 0; i < sellAmountSlider.value; i++)
        {
            Debug.Log(activeCryptoName);
            PlayerInventory.Instance.RemoveCrypto(activeCryptoName);
        }
        EconomyManager.Instance.ModifyPlayerCash((int)(activeCryptoPrice*sellAmountSlider.value));
        EconomyManager.Instance.UpdateCryptoHolders();
        AudioSource.PlayClipAtPoint(Audios.Instance.sonidoVenta, transform.position);
        CloseWindow();
    }
    

    public void CloseWindow()
    {
        backGroundPanel.SetActive(false);
        buyAndSellPanel.SetActive(false);
        buyPanel.SetActive(false);
        sellPanel.SetActive(false);
    }
}
