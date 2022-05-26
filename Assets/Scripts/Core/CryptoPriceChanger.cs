using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoPriceChanger : MonoBehaviour
{
    [SerializeField] public CryptoStruct[] cryptos;
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnDayChange += UpdateCryptoValues;
    }

    void UpdateCryptoValues(int day)
    {
        if (day % 3 == 1)
        {
            foreach (var cry in cryptos)
            {
                cry.currentPrice = Random.Range(cry.minPrice, cry.maxPrice);

            }
        }
        else
        {
            foreach (var cry in cryptos)
            {
                cry.currentPrice = Random.Range(cry.currentPrice - 100, cry.currentPrice + 100);

            }
        }
    }

    public void NewsCryptoValueChange(string cryptoName, int value)
    {
        for (int i = 0; i < cryptos.Length; i++)
        {
            if (cryptos[i].Name == cryptoName)
            {
                cryptos[i].currentPrice = value;
                break;
            }
        }
    }
}
