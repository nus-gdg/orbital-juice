using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public float spawnPeriod = 0.5f;
    public GameObject enemy;

    float _spawnTimeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        _spawnTimeElapsed += Time.deltaTime;

        if (_spawnTimeElapsed > spawnPeriod) {
            _spawnTimeElapsed -= spawnPeriod;

            Instantiate(enemy, new Vector2(Random.Range(-2.7f, 2.7f), transform.position.y), transform.rotation);   
        }
    }
}
