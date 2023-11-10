using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuop : MonoBehaviour
{
    [SerializeField] protected float speedMove;
    public float directX;
    void Update()
    {
        Move();
    }


    protected void Move()
    {
        transform.position += new Vector3(directX * speedMove * Time.deltaTime, 0, 0);
    }

}
