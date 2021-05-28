using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitspark : MonoBehaviour
{
    public float frameDuration = 0.04f;
    public List<Sprite> sprites;

    SpriteRenderer _spriteRenderer;
    int _index;
    float _timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > frameDuration) {
            _index++;
            _timeElapsed -= frameDuration;
        }

        if (_index >= sprites.Count) {
            Destroy(this.gameObject);
        } else {
            _spriteRenderer.sprite = sprites[_index];
        }
    }
}
