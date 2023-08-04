using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3; 
    public GameObject spawnPoint; 
    public int currentHealth; 
    private float collision_lasting = 0f;
    public float allowed_collision_lasting = 1f;
    private bool is_on_Ground;
    private bool is_touching_enemy;
    public GameObject player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    private bool AnotherHeartIsBought = false;
    private bool FirstUse = false;
    public CountingToRespawn countingToRespawn;
    public int ValueOfHeart = 1;


    void Start()
    {
        currentHealth = maxHealth;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(false);
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            is_on_Ground = true;
            collision_lasting = Time.time;
            HealthDecrease();
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            HealthDecrease();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            is_touching_enemy = true;
            collision_lasting = Time.time;
            HealthDecrease();
        }

        if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            HealthIncrease();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            is_on_Ground = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            is_touching_enemy = false;
        }
    }

    void HealthDecrease()
    {
        currentHealth = currentHealth - 1;

        if (AnotherHeartIsBought == false)
        {
            if (currentHealth == 2)
            {
                heart3.SetActive(false);
            }
            else if (currentHealth == 1)
            {
                heart2.SetActive(false);
            }
            else if (currentHealth == 0)
            {
                heart1.SetActive(false);
                Respawn();
            }
        }

        if(AnotherHeartIsBought)
        {
            if (currentHealth == 3)
            {
                heart4.SetActive(false);
            }
            else if (currentHealth == 2)
            {
                heart3.SetActive(false);
            }
            else if (currentHealth == 1)
            {
                heart2.SetActive(false);
            }
            else if (currentHealth == 0)
            {
                heart1.SetActive(false);
                Respawn();
            }
        }
    }

    void HealthIncrease()
    {
        currentHealth = currentHealth + 1;
        if (AnotherHeartIsBought == false)
        {
            if (currentHealth == 4)
            {
                Debug.Log("Current health is greater than maximum health!");
            }
            if (currentHealth == 3)
            {
                heart3.SetActive(true);
            }
            else if (currentHealth == 2)
            {
                heart2.SetActive(true);
            }
        }

        if (AnotherHeartIsBought)
        {
            if (currentHealth == 4)
            {
                heart4.SetActive(true);
            }
            if (currentHealth == 3)
            {
                heart3.SetActive(true);
            }
            else if (currentHealth == 2)
            {
                heart2.SetActive(true);
            }
        }
    }

    void Update()
    {

        if ((is_on_Ground && Time.time - collision_lasting >= allowed_collision_lasting) || (is_touching_enemy && Time.time - collision_lasting >= allowed_collision_lasting))
        {
            HealthDecrease();
            collision_lasting = Time.time; 
        }

         if (AnotherHeartIsBought && FirstUse)
          {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            maxHealth = 4;
            currentHealth = maxHealth;
            FirstUse = false;
          }
        

    }

    void Respawn()
    {
        countingToRespawn.ShowCounting();
        StartCoroutine(DelayedAction());

        player.transform.position = spawnPoint.transform.position;
        currentHealth = maxHealth;

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart3.SetActive(AnotherHeartIsBought);
    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(2f);
    
    }

    public void AddHeartWasBought()
    {
        AnotherHeartIsBought = true;
        FirstUse = true;
    }

}
        
