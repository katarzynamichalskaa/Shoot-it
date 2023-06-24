using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject kulkaPrefab;
    public Transform miejsceStrzalu;
    public float silaStrzalu = 10f;
    public float czasZyciaKulki = 0.5f;
    public float predkoscKulki = 5f;

    private GameObject aktywnaKulka;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && aktywnaKulka == null)
        {
            Strzelaj();
        }
    }

    void Strzelaj()
    {
        if (Time.timeScale == 1f)
        {
            Vector3 myszkaPozycja = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 kierunekStrzalu = (myszkaPozycja - miejsceStrzalu.position).normalized;

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

