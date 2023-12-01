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
    [SerializeField] WheelCar leftWheel;
    [SerializeField] WheelCar rightWheel;
    bool isBoosting;
    [SerializeField] GameObject boostEffect;

    [SerializeField] SmokeCar smoke;
    private void Awake()
    {
        speedCar = speedNormal;
        rigidCar = GetComponent<Rigidbody2D>();
    }

    [Obsolete]
    private void Update()
    {
        CheckBoost();
        Move();
        CheckEndGame();
    }

    [Obsolete]
    private void CheckEndGame()
    {
        if (transform.position.x >= GameScene12Manager.ins.endPosition.position.x - 10f && !GameScene12Manager.ins.isEndGame)
        {
            GameScene12Manager.ins.isEndGame = true;
            StopAllCoroutines();
            StartCoroutine(StartEndScene());
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
        if (Input.GetMouseButtonDown(0) && !GameScene12Manager.ins.isEndGame)
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

    [Obsolete]
    IEnumerator StartEndScene()
    {
        //Scale cam
        Camera cam = Camera.main;
        float startSize = cam.orthographicSize;
        float endSize = (4f / 5) * startSize;
        float maxDist = (GameScene12Manager.ins.endPosition.position.x - transform.position.x);
        float curDist;
        boostEffect.SetActive(false);
        while (transform.position.x <= GameScene12Manager.ins.endPosition.position.x)
        {
            speedCar = speedNormal;
            curDist = GameScene12Manager.ins.endPosition.position.x - transform.position.x;
            cam.orthographicSize = startSize + (endSize - startSize) * (1-curDist/maxDist);
            yield return new WaitForEndOfFrame();
        }
        cam.orthographicSize = endSize;
        GameScene12Manager.ins.shopKeeper.transform.eulerAngles += new Vector3(0, 180, 0);
        speedCar = 0;

        float eslapsed = 0;
        float seconds = 1f;

        Vector3 start = transform.position;
        Vector3 end = new Vector3(GameScene12Manager.ins.endPosition.position.x + 2f + (3f / 4) * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);

        while(eslapsed <= seconds)
        {
            leftWheel.RotateWheel((speedNormal - speedReduce) / speedNormal);
            rightWheel.RotateWheel((speedNormal - speedReduce) / speedNormal);
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            if (eslapsed >= seconds/4 && !smoke.gameObject.active)
            {
                smoke.gameObject.SetActive(true);
                smoke.Enable(seconds - eslapsed);
            }
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        smoke.gameObject.SetActive(false);
        GameScene12Manager.ins.EndScene();
    }

}
