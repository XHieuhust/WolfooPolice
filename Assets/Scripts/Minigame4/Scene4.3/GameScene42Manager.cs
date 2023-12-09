using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene42Manager : MonoBehaviour
{
    public static GameScene42Manager ins;
    int point;
    [SerializeField] int maxPoint;
    [SerializeField] ProgressBarScene42 barProgress;
    [SerializeField] public WolfBanTocDo wolfoo;
    private void Start()
    {
        ins = this;
    }

    public void UpdatePoint(bool isIllegal, Transform posEnemyCar)
    {
        wolfoo.Notice(isIllegal, posEnemyCar);
        if (isIllegal)
        {
            point++;
            barProgress.UpdateBarProgress(point, maxPoint);
            if (point == maxPoint)
            {
                Debug.Log("EndGame");
            }
        }

    }

}
