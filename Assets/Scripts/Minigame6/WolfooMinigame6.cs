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

    [SerializeField] private float JumpBackForce;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hightYonGround = transform.position.y;
    }

    private void Update()
    {
        Move();
        Jump();
        CheckFallOnPit();
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
        if (Input.GetMouseButtonDown(0) && !isHitted)
        {
            if (CheckOnGround())
            {
                rigid.AddForce(Vector2.up * forceJump);
            }
        }
    }

    private void Move()
    {
        if (!isHitted && !isFallingDown)
        {
            speed = speedNormal;
        }
        else
        {
            speed = 0;
        }
        if (!CheckNearOb()) rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obsacle"))
        {
            RaycastHit2D rayCheck = Physics2D.Raycast(PosRayRight.position, Vector2.right, lengthRay, layer);
            if (rayCheck)
            {
                collision.gameObject.GetComponent<Collider2D>().enabled = false;
                Hitted();
            }
        }

        if (collision.gameObject.CompareTag("Pit"))
        {
            transform.position = new Vector3(collision.transform.position.x, transform.position.y, transform.position.z);
            JumpBack();
        }
    }

    private void JumpBack()
    {
        StartCoroutine(nameof(StartJumpBack));
    }

    IEnumerator StartJumpBack()
    {
        yield return new WaitForSeconds(1f);
        rigid.AddForce(Vector2.up * JumpBackForce);
        isFallingDown = false;
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
        skeleton.AnimationState.SetAnimation(0, "Run_ninja", true);
        isHitted = false;
    }

    void CheckFallOnPit()
    {
        if ((transform.position.y <= hightYonGround - 1f) && !isFallingDown)
        {
            isFallingDown = true;
        }
    }



}
