using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform gracz;
    public Vector3 odlegloscOffset = new Vector3(0f, 0f, -10f);
    public float predkoscPodazania = 5f;

    void Update()
    {
        if (gracz != null)
        {
            Vector3 docelowaPozycja = gracz.position + odlegloscOffset;
            transform.position = Vector3.Lerp(transform.position, docelowaPozycja, predkoscPodazania * Time.fixedDeltaTime);
        }
    }
}
