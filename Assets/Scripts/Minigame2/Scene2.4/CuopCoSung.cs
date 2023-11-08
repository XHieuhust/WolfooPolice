using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuopCoSung : Cuop
{
    GameObject police;
    [SerializeField] GameObject bullet;
    bool isShooting;

    private void Start()
    {
        police = GameScene24Manager.ins.police;
    }
    void Update()
    {
        Move();
        CheckToShoot();
    }

    void CheckToShoot()
    {
        if (police.GetComponent<PoliceBatCuop>().isShooting && !isShooting)
        {
            if (transform.position.x > police.transform.position.x +3f && transform.position.x < Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect)
            {
                GameObject bulletShoot = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletShoot.GetComponent<Bullet>().ShotToGoal(police.transform.position);
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
        isShooting = true;
        yield return new WaitForSeconds(1.5f);
        isShooting = false;
    }
}
