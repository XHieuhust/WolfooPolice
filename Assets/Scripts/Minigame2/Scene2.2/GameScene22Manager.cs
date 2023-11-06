using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene22Manager : MonoBehaviour
{
    public static GameScene22Manager ins;
    int cntTurn;
    [SerializeField] QuanLyTrangPhuc day1;
    [SerializeField] QuanLyTrangPhuc day2;

    private void Start()
    {
        ins = this;
        StartTurn();
    }

    public void UpdateTurn()
    {
        cntTurn++;
        if (cntTurn == 4)
        {
            Debug.Log("end");
        }
        else 
        { 
            day2.InstantinateTrangPhuc(cntTurn);
            day1.InstantinateTrangPhuc(cntTurn);
        }
    }

    void StartTurn()
    {
        day2.InstantinateTrangPhuc(cntTurn);
        day1.InstantinateTrangPhuc(cntTurn);
    }
}
