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
    [SerializeField] GameObject boostSystem;
    public bool isEndGame;
    [SerializeField] GameObject policeStation;


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
            if (point >= maxPoint)
            {
                isEndGame = true;
                StopAllCoroutines();
                EndScene();
            }
            starManager.UpdatePosIcon(1.0f * point / maxPoint);
            barManager.UpdateBarFill(1.0f * point / maxPoint);

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
        boostSystem.SetActive(true);
        yield return new WaitForSeconds(timeSpeedUp);
        scaleSpeed = 1f;
        boostSystem.SetActive(false);

    }

    void StopCouroutineS()
    {
        scaleSpeed = 1;
        StopAllCoroutines();
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(2f);
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
