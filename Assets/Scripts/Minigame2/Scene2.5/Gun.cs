using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public void Shooting(Vector3 goalPosition)
    {
        GameObject bulletShoot = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletShoot.GetComponent<Bullet>().ShotToGoal(goalPosition);
    }
}
