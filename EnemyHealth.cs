using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private float collision_lasting = 0f;
    public float allowed_collision_lasting = 1f;
    private bool is_on_Ground;
    public GameObject enemy;
    public GameObject enemySeeker;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;


    void Start()
    {
        currentHealth = maxHealth;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            is_on_Ground = true;
            collision_lasting = Time.time;
            HealthDecrease();
        }

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);

            HealthDecrease();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            is_on_Ground = false;
        }
    }

    void HealthDecrease()
    {
        currentHealth = currentHealth - 1;

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
            Destroy(enemy);
            Destroy(enemySeeker);
        }
    }

    void Update()
    {
        if (is_on_Ground && Time.time - collision_lasting >= allowed_collision_lasting)
        {
            HealthDecrease();
            collision_lasting = Time.time;
        }
    }

}
