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
    [SerializeField] MayBanTocDo mayBanToc;
    [SerializeField] SpawnEnemyCar spawnEnemy;
    //transitionScene
    [SerializeField] Image enemyCarChased;
    [SerializeField] Image NoticeEnemyCarChased;
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
                PlayTransitionScene();
            }
        }

    }

    void PlayTransitionScene()
    {
        StartCoroutine(TransitionScene());
    }

    IEnumerator TransitionScene()
    {
        spawnEnemy.StopSpawn();
        yield return new WaitForSeconds(3f);
        NoticeEnemyCarChased.gameObject.SetActive(true);
        bool isActive = false;
        enemyCarChased.gameObject.SetActive(true);
        while(enemyCarChased)
        {
            if (enemyCarChased.transform.position.x >= Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect * 1/2 && !isActive)
            {
                mayBanToc.UpdateEndLine(enemyCarChased.transform);
                isActive = true;
            }
            if(enemyCarChased.transform.position.x <= Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect * 1 / 2)
            {
                mayBanToc.StopFollowEnemyCar();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
