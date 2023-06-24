using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // prędkość poruszania się postaci

    Rigidbody2D rb; // komponent Rigidbody
    float horizontalMovement; // wartość przesunięcia w poziomie
    float verticalMovement; // wartość przesunięcia w pionie

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // pobranie komponentu Rigidbody z obiektu
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

    void Update()
    {
        // pobranie wartości w osiach x i z z klawiszy A, D, W, S
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        // Obliczanie kąta obrotu na podstawie pozycji myszki
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Obracanie postaci w kierunku myszki
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // obliczenie wektora poruszania się postaci
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f).normalized * speed * Time.fixedDeltaTime;

        // poruszanie się postaci na skos
        if (horizontalMovement != 0f && verticalMovement != 0f)
        {
            movement *= 0.7f; // zmniejszenie prędkości ruchu na skos
        }

        // poruszanie się postaci za pomocą Rigidbody
        rb.MovePosition(transform.position + movement);
    }

}
