using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour
{
    public Text Pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                Pause.text = " ";
            }
            else
            {
                Time.timeScale = 0f;
                Pause.text = "GAME PAUSED ";
            }
        }
    }
}
