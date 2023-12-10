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
    [SerializeField] SpawnEnemyCar spawnEnemyCar;
    [SerializeField] GameObject carBeChased;
    [SerializeField] WolfBanTocDo wolf;
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
            barProgress.UpdateBarProgress(1.0f * point/maxPoint);
            if (point == maxPoint)
            {
                EndPanel();
            }
        }

    }

    public void EndPanel()
    {
        StartCoroutine(StartEndPanel());
    }

    IEnumerator StartEndPanel()
    {
        spawnEnemyCar.EndGame();
        yield return new WaitForSeconds(3f);
        carBeChased.SetActive(true);
        wolf.JumpHigh();
        yield return new WaitForSeconds(2f);
    }

}
