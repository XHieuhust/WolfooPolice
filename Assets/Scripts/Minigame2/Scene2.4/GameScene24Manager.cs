using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene24Manager : MonoBehaviour
{
    public static GameScene24Manager ins;
    public int point;
    [SerializeField] int maxPoint;
    [SerializeField] public GameObject police;
    private void Start()
    {
        ins = this;
    }

    public void UpdatePoint()
    {
        point++;
        if(point == maxPoint)
        {
            ScenesManager.ins.LoadScene("Scene2.5");
        }
    }
}
