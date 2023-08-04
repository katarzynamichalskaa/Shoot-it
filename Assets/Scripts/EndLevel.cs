using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    private bool HasKey = false;
    private bool WasKeyBought = false;
    private bool FirstCheck = true;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            HasKey = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            if(HasKey)
            {
                ChangeToNextScene();
            }

            if(HasKey==false)
            {
                Debug.Log("Nie masz klucza");
            }

            if(WasKeyBought && FirstCheck)
            {
                ChangeToNextScene();
                FirstCheck = false;
            }


        }
    }

    public void ChangeToNextScene()
    {
        SceneManager.LoadScene("Shop");
        HasKey = false;
    }

    public void AddKeyWasBought()
    {
        WasKeyBought = true;
    }
}
