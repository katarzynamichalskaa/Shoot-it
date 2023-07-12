using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    private bool Was_HeartBought = false;
    private bool Was_SkinBought = false;
    private bool Was_KeyBought = false;
    private bool HeartFirstCheck = true;
    private bool SkinFirstCheck = true;
    private bool KeyFirstCheck = true;
    private int HeartPrice = 3;
    private int SkinPrice = 10;
    private int KeyPrice = 20;

    void Update()
    {
        if(Was_HeartBought && HeartFirstCheck)
        {
            coinCount = coinCount - HeartPrice;
            HeartFirstCheck = false;

        }

        if (Was_SkinBought && SkinFirstCheck)
        {
            coinCount = coinCount - SkinPrice;
            SkinFirstCheck = false;
        }

        if (Was_KeyBought && KeyFirstCheck)
        {
            coinCount = coinCount - KeyPrice;
            KeyFirstCheck = false;
        }
    }

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

    }

    public static int ReturnCoinAmount()
    {
        return coinCount;
    }

    public void WasHeartBought()
    {
        Was_HeartBought = true;
    }

    public void WasSkinBought()
    {
        Was_SkinBought = true;
    }

    public void WasKeyBought()
    {
        Was_KeyBought = true;
    }

}
