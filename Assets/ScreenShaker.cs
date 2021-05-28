using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public static ScreenShaker Instance;

    public float shakes = 5;
    public float magnitude = 0.05f; 
    public float shakePeriod = 0.5f;

    Vector3 _initialPosition;

    bool _shaking = false;
    float _timeElapsed = 0f;
    float _shakesOccured = 0;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        Instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
        if (!_shaking) {
            return;
        }

        _timeElapsed += Time.deltaTime;

        if (_timeElapsed >= shakePeriod) {
            _timeElapsed -= shakePeriod;
            _shakesOccured++;

            float horizontalShake = Random.Range(-magnitude, magnitude);
            float verticalShake = Random.Range(-magnitude, magnitude);

            transform.position
                = _initialPosition + new Vector3(_initialPosition.x + horizontalShake, _initialPosition.y + verticalShake, 0f);
        }

        if (_shakesOccured == shakes) {
            _shaking = false;
            transform.position = _initialPosition;
        }
    }

    public void Shake()
    {
        _shaking = true;
        _timeElapsed = shakePeriod;
        _shakesOccured = 0;
    }
}
