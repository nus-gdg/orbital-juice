using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfdestructAfterSeconds : MonoBehaviour
{
    public float secondsToLive;

    void Start() {
        StartCoroutine("SelfDestruct");
    }

    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(secondsToLive);
        Destroy(this.gameObject);
    }
}
