using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shop : MonoBehaviour
{

    public int nextSceneIndex = 2;
    private int HeartPrice = 3;
    private int SkinPrice = 10;
    public Health health;
    public ChangeSkin skin;
    public CoinsCounter conuter;

    void Update()
    {
        CheckIfShop();
    }

    void CheckIfShop()
    {
        if (SceneManager.GetActiveScene().name == "Shop")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Next");
                nextSceneIndex++;
            }
        }
    }

    public void BuyHeart()
    {
        int current_Amount = Coin.ReturnCoinAmount();

        if (current_Amount >= HeartPrice)
        {
            PlayerPrefs.SetInt("CoinCount", current_Amount - HeartPrice);
            PlayerPrefs.Save();

            health.AddHeartWasBought();

        }

        else if(current_Amount != HeartPrice)
        {
            Debug.Log("You don't have enough money to purchase this!");
        }
    }

    public void BuySkin()
    {
        int current_Amount = Coin.ReturnCoinAmount();

        if (current_Amount >= SkinPrice)
        {
            PlayerPrefs.SetInt("CoinCount", current_Amount - SkinPrice);
            PlayerPrefs.Save();

            skin.AddSkinWasBought();

        }

        else if (current_Amount != SkinPrice)
        {
            Debug.Log("You don't have enough money to purchase this!");
        }
    }

}
