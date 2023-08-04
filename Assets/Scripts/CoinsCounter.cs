using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinsCounter : MonoBehaviour
{
    public Text coinCounterText;

    private void Update()
    {
        int count = Coin.ReturnCoinAmount();
        coinCounterText.text = "x" + count.ToString();
    }
}
