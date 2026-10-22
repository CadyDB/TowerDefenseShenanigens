using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int coins = 10;
    public TextMeshProUGUI coinTxt;

    public int Coins 
    { 
        get {return coins;}
        set {coins = value;}
    }

    private void Awake()
    {
        instance = this;
        UpdateCoins(0);
    }

    public void UpdateCoins(int changeAmount)
    {
        coins += changeAmount;

        coinTxt.text = coins.ToString();
    }
}
