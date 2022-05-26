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
                cry.currentPrice = Random.Range((cry.currentPrice*80)/100, (cry.currentPrice*120)/100);

            }
        }
    }

    public void NewsCryptoValueChange(CryptoStruct crypto)
    {
        Debug.Log("crypto modificada");
        for (int i = 0; i < cryptos.Length; i++)
        {
            if (cryptos[i].Name == crypto.Name)
            {
                cryptos[i].currentPrice = crypto.currentPrice;
                cryptos[i].minPrice = crypto.minPrice;
                cryptos[i].maxPrice = crypto.maxPrice;
                break;
            }
        }
    }
}
