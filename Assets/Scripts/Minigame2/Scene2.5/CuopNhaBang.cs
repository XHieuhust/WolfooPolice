using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity; 

public class CuopNhaBang : MonoBehaviour
{
    bool isBeingShooted;
    bool isAttacking;
    Vector3 startPos;
    Vector3 startScale;
    [SerializeField] float speedEnlarge;
    [SerializeField] float limitScale;
    [SerializeField] float timeAttack;
    [SerializeField] float speedDelarge;
    [SerializeField] float timeBeShooted;
    [SerializeField] bool isHoaDien;
    [SerializeField] float maxBulletOfTurn;
    int cntBulletOfTurn;
    [SerializeField] SkeletonAnimation anim;
    private void Awake()
    {
        startPos = transform.position;
        startScale = transform.localScale;
    }

    private void Update()
    {
        if (!isBeingShooted && !isAttacking)
        {
            transform.localScale += new Vector3(speedEnlarge * Time.deltaTime, speedEnlarge * Time.deltaTime, 0);
        }

        if (transform.localScale.x > limitScale)
        {
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        anim.AnimationState.SetAnimation(0, "Jump", true);
        isAttacking = true;
        yield return new WaitForSeconds(timeAttack);
        isAttacking = false;
        StartTurn();
    }

    void StartTurn()
    {
        anim.AnimationState.SetAnimation(0, "Angry", true);
        isHoaDien = false;
        cntBulletOfTurn = 0;
        transform.position = startPos;
        transform.localScale = startScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isHoaDien)
        {
            Vector3 newScale = transform.localScale - new Vector3(speedDelarge, speedDelarge, 0);
            if (newScale.x <= startScale.x)
            {
                transform.localScale = startScale;
            }
            else
            {
                transform.localScale = newScale;
            }
            
            StartCoroutine(BeingShooted());
            cntBulletOfTurn++;
            GameScene25Manager.ins.UpdatePoint();
            if(cntBulletOfTurn == maxBulletOfTurn)
            {
                isHoaDien = true;
            }
        }
    }

    IEnumerator BeingShooted()
    {
        anim.AnimationState.SetAnimation(0, "Kneel", true);
        isBeingShooted = true;
        yield return new WaitForSeconds(timeBeShooted);
        isBeingShooted = false;
        anim.AnimationState.SetAnimation(0, "Angry", true);
    } 
}
