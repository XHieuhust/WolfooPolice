using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene52Manager : MonoBehaviour
{
    public static GameScene52Manager ins;
    [SerializeField] StarManagerScene52 starManager;
    [SerializeField] BarScene52Manager barManager;
    private int point;
    [SerializeField] int maxPoint;
    public bool isEndGame;

    [SerializeField] GameObject policeStation;


    [SerializeField] public float timeEndScene;
    public float scaleSpeed;
    [SerializeField] float timeSpeedUp;
    [SerializeField] SteeringWheel steering;
    private void Awake()
    {
        scaleSpeed = 1;
        ins = this;
    }

    public void UpdatePoint()
    {
        if (!isEndGame)
        {
            point++;
            starManager.UpdatePosIcon(1.0f * point / maxPoint);
            barManager.UpdateBarFill(1.0f * point / maxPoint);
            if(point >= maxPoint)
            {   
                isEndGame = true;
                StopAllCoroutines();
                EndScene();
            }
        }
    }

    private void EndScene()
    {
        StartCoroutine(nameof(StartEndScene));

    }

    public void SpeedUp()
    {
        if (!isEndGame)
        {
            StartCoroutine(nameof(StartToSpeedUp));
        }

    }

    IEnumerator StartToSpeedUp()
    {
        scaleSpeed = 2f;
        yield return new WaitForSeconds(timeSpeedUp);
        scaleSpeed = 1f;
    }

    void StopCouroutineS()
    {
        scaleSpeed = 1;
        StopAllCoroutines();
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
        policeStation.SetActive(true);
        steering.EndScene();
        yield return new WaitForSeconds(2f);
        CompleteMinigame5();
    }

    public void CompleteMinigame5()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
