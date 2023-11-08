using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBatCuop : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public bool isShooting;

    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
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
        yield return new WaitForSeconds(0.5f);
        isShooting = true;
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }
}
