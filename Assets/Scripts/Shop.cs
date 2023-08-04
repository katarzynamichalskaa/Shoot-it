using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shop : MonoBehaviour
{

    public int nextSceneIndex = 2;
    private int HeartPrice = 3;
    private int SkinPrice = 10;
    private int KeyPrice = 20;
    private int AttackPrice = 50;
    public Health health;
    public ChangeSkin skin;
    public Coin coin;
    public EndLevel level;
    public Shooting attack; 


    void Start()
    {

        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            health = playerObject.GetComponent<Health>();
            skin = playerObject.GetComponent<ChangeSkin>();
            coin = playerObject.GetComponent<Coin>();
            attack = playerObject.GetComponent<Shooting>();
            level = playerObject.GetComponent<EndLevel>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

    }

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
            health.AddHeartWasBought();
            coin.WasHeartBought();
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
            skin.AddSkinWasBought();
            coin.WasSkinBought();
        }

        else if (current_Amount != SkinPrice)
        {
            Debug.Log("You don't have enough money to purchase this!");
        }
    }

    public void BuyKey()
    {
        int current_Amount = Coin.ReturnCoinAmount();

        if (current_Amount >= KeyPrice)
        {
            level.AddKeyWasBought();
            coin.WasKeyBought();
        }

        else if (current_Amount != KeyPrice)
        {
            Debug.Log("You don't have enough money to purchase this!");
        }
    }

    public void BuyAttack()
    {
        int current_Amount = Coin.ReturnCoinAmount();

        if (current_Amount >= AttackPrice)
        {
            attack.AddAttackWasBought();
            coin.WasAttackBought();
        }

        else if (current_Amount != AttackPrice)
        {
            Debug.Log("You don't have enough money to purchase this!");
        }
    }



}
