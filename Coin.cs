using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinCount = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            AddCoins(5);
        }
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
    }

    public static int ReturnCoinAmount()
    {
        return PlayerPrefs.GetInt("CoinCount", 0);
    }
}
