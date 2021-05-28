using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1;
    
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    public GameObject boom;
    public GameObject spark;

    float _moveSpeed;

    public float shakes = 3;
    public float magnitude = 0.05f; 
    public float shakePeriod = 0.05f;
    bool _hurting = false;
    float _timeElapsed = 0f;
    float _shakesOccured = 0;
    Vector3 _hitPosition;

    void Start()
    {
        _moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (_hurting)
        {
            Hurt();
        }
        else
        {
            Advance();
        }
    }

    void Advance()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - _moveSpeed * Time.deltaTime);

        if (transform.position.y < -5.4f) {
            Destroy(this.gameObject);
        }
    }

    void Hurt()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= shakePeriod)
        {
            _timeElapsed -= shakePeriod;
            _shakesOccured++;

            float horizontalShake = Random.Range(-magnitude, magnitude);

            transform.position
                = new Vector3(_hitPosition.x + horizontalShake, _hitPosition.y, _hitPosition.z);
        }

        if (_shakesOccured == shakes)
        {
            _hurting = false;
            transform.position = _hitPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        health -= 1;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            GetHurt();
        }
    }

    void Die()
    {
    
        GameObject explosionSoundObject = GameObject.Find("Explosion Sound");
        if (explosionSoundObject != null)
        {
            explosionSoundObject.GetComponent<PlayableAudio>().Play();
        }

        ScreenShaker shaker = ScreenShaker.Instance;
        if (shaker !== null)
        {

        } 
        .Shake();
        Instantiate(boom, new Vector3(transform.position.x, transform.position.y, -1f), transform.rotation);
        Destroy(this.gameObject);
    }

    void GetHurt()
    {
        //Instantiate(spark, new Vector3(transform.position.x, transform.position.y, -2f), transform.rotation);
        _hitPosition = transform.position;
        _hurting = true;
        _timeElapsed = shakePeriod;
        _shakesOccured = 0;
    }
}
