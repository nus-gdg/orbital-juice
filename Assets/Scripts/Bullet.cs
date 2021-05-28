using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;

    float currentSpeed = 0f;

    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

        transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed * Time.deltaTime);
    
        if (transform.position.y > 5.5f) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }
}
