using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinsCounter : MonoBehaviour
{
    public Text coinCounterText;
    public Shop shop;


    private void Update()
    {
        int Count = PlayerPrefs.GetInt("CoinCount", 0);

 
        PlayerPrefs.SetInt("CoinCount", Count);
        PlayerPrefs.Save();
        

        coinCounterText.text = "x" + Count.ToString();

    }
}
