using UnityEngine;

[CreateAssetMenu(menuName = "Cryptos/Crypto")]
public class CryptoStruct : ScriptableObject
{
    public string Name;
    public int currentPrice;
    public int minPrice;
    public int maxPrice;
    
}
