using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDuoiBat : MonoBehaviour
{
    public static PanelDuoiBat ins;
    [SerializeField] List<RoadChaseEnemy> ListRoad;
    [SerializeField] public CarViPham carViPham;
    public bool isEndGame;
    float eslapsed;
    [SerializeField] float endTime;
    public bool isStopGame;
    
    private void Start()
    {
        ins = this;
    }
    public void Update()
    {
        if (eslapsed >= endTime)
        {
            isStopGame = true;
        }
        eslapsed += Time.deltaTime;
    }
    public void PoliceCarHitCar()
    {
        for(int i = 0; i < ListRoad.Count; ++i)
        {
            ListRoad[i].DecreaseSpeed();
        }
        carViPham.UpDateSpeedWhenCarHit();
    }

    public void BecomeNormal()
    {
        for (int i = 0; i < ListRoad.Count; ++i)
        {
            ListRoad[i].InceaseToNormal();
        }
        carViPham.BecomeNormal();
    }
}
