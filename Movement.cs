using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; 

    Rigidbody2D rb; 
    float horizontalMovement; 
    float verticalMovement; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

    void Update()
    {

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        if (Time.timeScale == 1f)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        else if (Time.timeScale == 0f)
        {
            Debug.LogError("Game is paused");
        }

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f).normalized * speed * Time.fixedDeltaTime;

        if (horizontalMovement != 0f && verticalMovement != 0f)
        {
            movement *= 0.7f; 
        }

        rb.MovePosition(transform.position + movement);
    }

}
