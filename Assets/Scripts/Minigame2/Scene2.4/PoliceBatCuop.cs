using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PoliceBatCuop : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public bool isShooting;
    [SerializeField] SkeletonAnimation anim;
    public bool isBeShooted;
    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting && !isBeShooted)
        {   
            Vector3 goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(goalPosition.x > transform.position.x + 3f && goalPosition.y > transform.position.y)
            {
                GameObject bulletShoot = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletShoot.GetComponent<Bullet>().ShotToGoal(goalPosition);
                bulletShoot.GetComponent<Bullet>().isOfPolice = true;
                WaitToShooting();
            }
        }
    }

    void WaitToShooting()
    {
        StartCoroutine(InTimeShooting());
    }

    IEnumerator InTimeShooting()
    {
        anim.AnimationState.SetAnimation(0, "Hide", false);
        yield return new WaitForSeconds(0.5f);
        isShooting = true;
        yield return new WaitForSeconds(1f);
        isShooting = false;
        anim.AnimationState.SetAnimation(0, "Idle", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!collision.gameObject.GetComponent<Bullet>().isOfPolice)
            {
                beShooted();
            }
        }
    }

    void beShooted()
    {
        StartCoroutine(InTimeBeShooted());
    }

    IEnumerator InTimeBeShooted()
    {
        isBeShooted = true;
        anim.AnimationState.SetAnimation(0, "Crying", true);
        yield return new WaitForSeconds(1.5f);
        isBeShooted = false;
        anim.AnimationState.SetAnimation(0, "Idle", true);

    }
}
