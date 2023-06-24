using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void TogglePause()
    {
        if(Input.GetKeyDown("space"))
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f; 
            }
            else
            {
                Time.timeScale = 0f; 
            }
    }
}
