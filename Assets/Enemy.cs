using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    public GameObject boom;

    float _moveSpeed;

    void Start() {
        _moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - _moveSpeed * Time.deltaTime);

        if (transform.position.y < -5.4f) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        health -= 1;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        ScreenShaker.Instance.Shake();
        Instantiate(boom, new Vector3(transform.position.x, transform.position.y, -1f), transform.rotation);
        Destroy(this.gameObject);
    }
}
