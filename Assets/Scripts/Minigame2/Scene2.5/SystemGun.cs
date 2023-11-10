using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemGun : MonoBehaviour
{
    [SerializeField] GameObject leftGun;
    [SerializeField] GameObject rightGun;
    bool isShooting;

    private void Update()
    {
        CheckShoot();
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            Vector3 goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (goalPosition.x >= 0)
            {
                rightGun.GetComponent<Gun>().Shooting(goalPosition);
            }
            else
            {
               leftGun.GetComponent<Gun>().Shooting(goalPosition);
            }
            WaitToShooting();
        }
    }

    void WaitToShooting()
    {
        StartCoroutine(InTimeShooting());
    }

    IEnumerator InTimeShooting()
    {
        isShooting = true;
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }
}
