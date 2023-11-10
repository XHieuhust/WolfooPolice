using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeBg : MonoBehaviour
{
    [SerializeField] float speed;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect / (sprite.size.x / 2),
                                            Camera.main.orthographicSize / (sprite.size.y / 2));
    }
    void Update()
    {
        DecreaseShade();
    }

    private void DecreaseShade()
    {
        if(sprite.color.a >= 0)
        {
            sprite.color -= new Color(0, 0, 0, speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
