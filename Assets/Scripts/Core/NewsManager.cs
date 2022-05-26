using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsManager : Singleton<NewsManager>
{
    private CryptoStruct crypto;
    [SerializeField] private string[] positiveNews;
    [SerializeField] private string[] negativeNews;
    private bool active;

    private int upOrDown;
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnDayChange += RandomizeNewsPosibility;
    }

    void RandomizeNewsPosibility(int day)
    {
        if (day % 3 == 1)
        {
            int rand = Random.Range(1, 101);
            if(rand > 60)
                GenerateNew();
        }
        else
        {
            int rand = Random.Range(1, 101);
            if(rand > 15)
                GenerateNew();
        }
    }

    void GenerateNew()
    {
        if (!active)
        {
            crypto = EconomyManager.Instance.GetRandomCrypto();
            EconomyManager.Instance.OnDayChange += ApplyEffects;
            Debug.Log("noticia generada");
            Debug.Log("Crypto a alterar " + crypto.Name);
            upOrDown = Random.Range(0,2);
            if (upOrDown == 0)
            {
                NewsDisplay.Instance.SetText(positiveNews[Random.Range(0,3)] + crypto.Name);
            }
            else
            {
                NewsDisplay.Instance.SetText(negativeNews[Random.Range(0,3)] + crypto.Name);
            }
            active = true;
        }
    }
    
    void ApplyEffects(int day)
    {
        if (active)
        {
            int randomPorcentaje = Random.Range(30, 71);

            
            if (upOrDown == 0)
            {
                crypto.currentPrice += (crypto.currentPrice * randomPorcentaje) / 100;
                crypto.minPrice = (int)(crypto.currentPrice * 0.6f);
                crypto.maxPrice = (int)(crypto.currentPrice * 2f);
            }
            else
            {
                crypto.currentPrice -= (crypto.currentPrice * randomPorcentaje) / 100;
                crypto.minPrice = (int)(crypto.currentPrice * 0.6f);
                crypto.maxPrice = (int)(crypto.currentPrice * 1.7f);
            }


            EconomyManager.Instance.OnDayChange -= ApplyEffects;
            active = false;
        }

    }
}
