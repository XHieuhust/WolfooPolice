using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene25Manager : MonoBehaviour
{
    public static GameScene25Manager ins;
    public int point;
    public int maxPoint;
    [SerializeField] ProgressBarScene25 BarProgress;
    private void Start()
    {
        ins = this;
    }
    public void UpdatePoint()
    {
        point++;
        BarProgress.UpdateBar(1.0f * point / maxPoint);
        if(point == maxPoint)
        {
            ScenesManager.ins.LoadScene("SceneMenu");
        }
    }


}
