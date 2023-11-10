using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeBgQuet : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect / (sprite.size.x / 2),
                                            Camera.main.orthographicSize / (sprite.size.y / 2));
    }


}
