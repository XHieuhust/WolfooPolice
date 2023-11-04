using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyCacBoPhan : MonoBehaviour
{
    public static QuanLyCacBoPhan ins;
    [SerializeField] int cntTrueBoPhan;
    [SerializeField] GameObject than;
    private void Start()
    {
        ins = this;
    }

    public void UpdateCntTrueBoPhan()
    {
        cntTrueBoPhan++;
        if(cntTrueBoPhan == 3)
        {
            NhapNhayThan();
        }
    }

    public void NhapNhayThan()
    {
        than.GetComponent<ThanSprite>().NhapNhay();
    }

}
