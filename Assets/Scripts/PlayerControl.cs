using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float reloadTime;
    public PlayableAudio shootSound;

    public GameObject bullet;

    float remainingReloadTime = 0f;

    void Update()
    {
        UpdateMovement();
        UpdateFire();
    }

    void UpdateMovement() {
        bool goLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A); 
        bool goRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        bool goUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool goDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        float horizontalDisplacement = 0f;
        float verticalDisplacement = 0f;

        if (goLeft && !goRight) {
            horizontalDisplacement = -moveSpeed * Time.deltaTime;
        }

        if (!goLeft && goRight) {
            horizontalDisplacement = moveSpeed * Time.deltaTime;
        }

        if (goUp && !goDown) {
            verticalDisplacement = moveSpeed * Time.deltaTime;
        }

        if (!goUp && goDown) {
            verticalDisplacement = -moveSpeed * Time.deltaTime;
        }

        transform.position = transform.position + new Vector3(horizontalDisplacement, verticalDisplacement, 0f);
    }

    void UpdateFire() {
        if (Input.GetKey(KeyCode.Space) && remainingReloadTime < 0.0f) {
            Instantiate(bullet, transform.position, transform.rotation);
            remainingReloadTime = reloadTime;

            if (shootSound != null) {
                shootSound.Play();
            }
        }

        remainingReloadTime -= Time.deltaTime;
    }
}
