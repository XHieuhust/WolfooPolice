using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class WolfooMinigame6 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    Rigidbody2D rigid;
    private float speed;
    [SerializeField] private float speedNormal;
    [SerializeField] private float forceJump;
    bool isOnGround;

    //System check falling down pit
    private float hightYonGround;
    public bool isFallingDown;
    bool isJumpingUp;

    // system check on ground
    RaycastHit2D rayLeft;
    RaycastHit2D rayRight;
    RaycastHit2D rayHorizontal;


    // BeHitted
    private bool isHitted;
    [SerializeField] private float timeBeHitted;

    [SerializeField] Transform PosRayLeft;
    [SerializeField] Transform PosRayRight;
    [SerializeField] private LayerMask layer;
    private float lengthRay = 0.2f;

    //boost
    public bool isBoosting;
    [SerializeField] private float speedBoost;
    [SerializeField] private float timeBoost;

    //end
    public Vector3 startPos;
    public Vector3 endPos;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);

        hightYonGround = transform.position.y;
        startPos = new Vector3(-(Camera.main.orthographicSize * Camera.main.aspect * 2 / 3), transform.position.y, transform.position.z);
        endPos = new Vector3(GameScene62Manager.ins.rihino.endPos.position.x - 2f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        Move();
        Jump();
        CheckFallOnPit();
        CheckEndGame();
    }

    bool CheckOnGround()
    {
        rayLeft = Physics2D.Raycast(PosRayLeft.position, Vector2.down, lengthRay, layer);
        rayRight = Physics2D.Raycast(PosRayRight.position, Vector2.down, lengthRay, layer);
        if (rayLeft || rayRight) return true;
        return false;
    }

    bool CheckNearOb()
    {
        rayHorizontal = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthRay, layer);
        if (rayHorizontal) return true;
        return false;
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0) && !isHitted && GameScene62Manager.ins.isStartGame && !GameScene62Manager.ins.isEndGame)
        {
            if (CheckOnGround())
            {
                rigid.AddForce(Vector2.up * forceJump);
                skeleton.AnimationState.SetAnimation(0, "Jump_Hight", false);
            }
        }
    }

    private void Move()
    {
        if (!isHitted && !isFallingDown && !isJumpingUp)
        {
            if (!isBoosting)
            {
                speed = speedNormal;
            }
            if (isBoosting)
            {
                speed = speedBoost;
                if (transform.position.y <= hightYonGround)
                {
                    transform.position = new Vector3(transform.position.x, hightYonGround + 0.05f, transform.position.z);
                    rigid.velocity = new Vector2(speed, 0);
                }
            }
        } else
        {
            speed = 0;
        }
        if (!CheckNearOb() && !GameScene62Manager.ins.isEndGame) rigid.velocity = new Vector2(speed, rigid.velocity.y);
        SetAnimRun();
    }

    private void SetAnimRun()
    {
        if (transform.position.y - hightYonGround >= 0.1f && rigid.velocity.y < 0 && !isHitted && !GameScene62Manager.ins.isEndGame)
        {
            skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            RaycastHit2D rayCheck = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthRay, layer);
            if (rayCheck)
            {
                if (!isBoosting)
                {
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    Hitted();
                }
                else
                {
                    collision.gameObject.GetComponent<ObsacleMinigame6>().Fly();
                }
            }
        }

        if (collision.gameObject.CompareTag("Pit"))
        {
            //transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
            float sizePit = collision.collider.bounds.size.x / 2;
            JumpBack(sizePit);
        }

        if (collision.gameObject.CompareTag("Buff"))
        {
            StartCoroutine(nameof(StartBoost));
        }
    }

    IEnumerator StartBoost()
    {
        isBoosting = true;
        yield return new WaitForSeconds(timeBoost);
        isBoosting = false;
    }

    private void JumpBack(float sizePit)
    {
        StartCoroutine(nameof(StartJumpBack), sizePit);
    }

    IEnumerator StartJumpBack(float sizePit)
    {
        yield return new WaitForSeconds(1.5f);
        Vector2 oldPos = transform.position;
        Vector2 newPos = new Vector3(transform.position.x + sizePit, hightYonGround + 0.5f, 0);
        float eslapsed = 0;
        float seconds = 0.75f;
        isFallingDown = false;
        isJumpingUp = true;
        skeleton.AnimationState.SetAnimation(0, "Jump_Hight", false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(oldPos, newPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = newPos;
        isJumpingUp = false;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
    private void Hitted()
    {
        StartCoroutine(nameof(StartBeHitted));
    }

    IEnumerator StartBeHitted()
    {
        isHitted = true;
        skeleton.AnimationState.SetAnimation(0, "Surprise_Idle", true);
        yield return new WaitForSeconds(timeBeHitted);
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        isHitted = false;
    }

    void CheckFallOnPit()
    {
        if ((transform.position.y <= hightYonGround - 1f) && !isFallingDown && !isJumpingUp)
        {
            isFallingDown = true;
        }
    }

    void CheckEndGame()
    {
        if (GameScene62Manager.ins.rihino.transform.position.x - transform.position.x <= Camera.main.orthographicSize * Camera.main.aspect && !GameScene62Manager.ins.isEndGame)
        {
            GameScene62Manager.ins.isEndGame = true;
            StartCoroutine(nameof(StartMoveToRihino));
        }
    }

    IEnumerator StartMoveToRihino()
    {
        rigid.velocity = Vector2.zero;
        Vector3 end = endPos;
        
        while (Vector2.Distance(transform.position, end) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speedNormal * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        skeleton.AnimationState.SetAnimation(0, "Cheer", true);
        GameScene62Manager.ins.rihino.SetAnimCry();
        yield return new WaitForSeconds(2f);
        GameScene62Manager.ins.LoadNewScene();
    }
}
