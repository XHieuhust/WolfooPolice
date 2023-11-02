using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toys : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector3 fallPositison;
    [SerializeField] float speedFall;
    [SerializeField] float length;
    Rigidbody2D rigidToy;
    private void Awake()
    {
        rigidToy = GetComponent<Rigidbody2D>();
        // Tam khong nam o chinh giua
        length = GetComponent<SpriteRenderer>().bounds.size.y/2;

  
        fallPositison = new Vector3(transform.position.x, transform.position.y - 2f + length, transform.position.z);
        transform.localScale = Vector2.zero;

    }

    private void Update()
    {
        if(transform.localScale.x < 0.64)
        {
            transform.position = Vector2.MoveTowards(transform.position, fallPositison, speedFall);
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);
        }else if(!RoundManager.ins.isPlayerbeHitted)
        {   
            rigidToy.velocity = new Vector2(-speedMove, 0);
        }
        else
        {
            rigidToy.velocity = Vector2.zero;
        }

        if(transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
