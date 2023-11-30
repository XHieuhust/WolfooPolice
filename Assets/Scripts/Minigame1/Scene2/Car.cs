using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] protected float speedNormal;
    [SerializeField] protected float speedBoost;
    protected float speedReduce = 5f;
    [SerializeField] private float speedCar;
    Rigidbody2D rigidCar;
    private float timeBoost = 1f;
    private float elapsed = 0f;
    int isOnObsacle;
    bool isEndGame;
    [SerializeField] WheelCar leftWheel;
    [SerializeField] WheelCar rightWheel;
    bool isBoosting;
    [SerializeField] GameObject boostEffect;

    [SerializeField] 
    private void Awake()
    {
        speedCar = speedNormal;
        rigidCar = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckBoost();
        Move();
        StopCar();
    }

    private void StopCar()
    {
        // When cameta stop at endPosition
        if(transform.position.x >= Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect / 2 * 4 / 5 && !isEndGame)
        {
            speedCar = 0;
            isEndGame = true;
            GameScene12Manager.ins.EndGame();
        }
    }

    private void Move()
    {   
        rigidCar.velocity = new Vector2(speedCar, rigidCar.velocity.y) ;
        leftWheel.RotateWheel(speedCar / speedNormal);
        rightWheel.RotateWheel(speedCar / speedNormal);
    }
 
    void CheckBoost()
    {
        if (Input.GetMouseButtonDown(0) && rigidCar.velocity.x != 0)
        {
            StopCoroutine(nameof(Boost));
            StartCoroutine(nameof(Boost));
        }
    }

    private IEnumerator Boost()
    {
        boostEffect.SetActive(true);
        elapsed = 0;
        
        while (elapsed <= timeBoost)
        {
            speedCar = speedNormal + speedBoost;
            if(isOnObsacle == 1 && speedCar > speedNormal + speedBoost - speedReduce)
            {
                speedCar = speedNormal + speedBoost - speedReduce;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        speedCar = speedNormal;
        boostEffect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            isOnObsacle++;
            if (isOnObsacle == 1)
            {
                speedCar -= speedReduce;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            isOnObsacle --;
            if (isOnObsacle == 0) speedCar += speedReduce;
                
        }
    }

    
}
