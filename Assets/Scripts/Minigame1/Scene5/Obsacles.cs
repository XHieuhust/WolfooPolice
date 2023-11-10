using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacles : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Rigidbody2D rigidObsacle;
    void Start()
    {
        rigidObsacle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameScene5Manager.ins.player.isBeHitted && !GameScene5Manager.ins.isPlayEndScene)
        {
            rigidObsacle.velocity = new Vector2(-speedMove, 0);
        }
        else
        {
            rigidObsacle.velocity = Vector2.zero;
        }
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f)
        {
            Destroy(gameObject);
        }
    }


}
