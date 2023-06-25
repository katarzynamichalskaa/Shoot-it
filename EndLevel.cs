using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    private bool HasKey = false;
    public int nextSceneIndex = 1;


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

          
        }
    }

    public void ChangeToNextScene()
    {
        SceneManager.LoadScene("Next");
        nextSceneIndex++;

    }
}
