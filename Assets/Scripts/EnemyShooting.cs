using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject kulkaPrefab;
    public Transform miejsceStrzalu;
    public float silaStrzalu = 10f;
    public float czasZyciaKulki = 0.5f;
    public float predkoscKulki = 5f;
    public Transform player;
    private GameObject aktywnaKulka;
    public float opoznienieStrzalu = 2f;
    public float interwalStrzalu = 2f;
    public float odlegloscMinStrzalu = 2f;

    void Start()
    {
        InvokeRepeating("Strzelaj", opoznienieStrzalu, interwalStrzalu);
    }

    void Strzelaj()
    {
        if (Time.timeScale == 1f)
        {
            float odlegloscDoPlayera = Vector3.Distance(transform.position, player.position);

            if (odlegloscDoPlayera > odlegloscMinStrzalu)
            {
                return; 
            }

            Vector3 kierunekStrzalu = (player.position - miejsceStrzalu.position).normalized;
            GameObject nowaKulka = Instantiate(kulkaPrefab, miejsceStrzalu.position, miejsceStrzalu.rotation);
            Rigidbody2D rb = nowaKulka.GetComponent<Rigidbody2D>();


            if (rb != null)
            {
                rb.velocity = kierunekStrzalu * predkoscKulki;
                Destroy(nowaKulka, czasZyciaKulki);
                aktywnaKulka = nowaKulka;
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
        if (aktywnaKulka != null)
        {
            Destroy(aktywnaKulka);
        }
    }

}
