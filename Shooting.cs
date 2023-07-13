using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform PlaceOfShoot;
    private float LifespanOfBullet = 0.5f;
    private float BulletVelocity = 80f;
    private float UpgradedBulletVelocity = 200f;
    private bool AttackIsBought = false;


    private GameObject activeBullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && AttackIsBought)
        {
            if (Input.GetMouseButtonDown(0) && activeBullet == null)
            {
                Shoot(UpgradedBulletVelocity);

                if(Input.GetKeyDown(KeyCode.Q))
                {
                    Shoot(BulletVelocity);
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0) && activeBullet == null)
            {
                Shoot(BulletVelocity);
            }
        }
    }

    void Shoot(float BulletVelocity)
    {
        if (Time.timeScale == 1f)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePos - PlaceOfShoot.position).normalized;

            GameObject newBullet = Instantiate(bulletPrefab, PlaceOfShoot.position, PlaceOfShoot.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = direction * BulletVelocity;
                Destroy(newBullet, LifespanOfBullet);
                activeBullet = newBullet;
            }
            else
            {
                Debug.LogError("KulkaPrefab nie zawiera komponentu Rigidbody2D!");
            }
        }

        else if (Time.timeScale == 0f)
        {
            Debug.LogError("Game is paused");
        }
    }

    public void OnDestroy()
    {
        if (activeBullet != null)
        {
            Destroy(activeBullet);
        }
    }

    public void AddAttackWasBought()
    {
        AttackIsBought = true;
    }
}
