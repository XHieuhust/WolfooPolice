using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class GameScene31Manager : MonoBehaviour
{
    public static GameScene31Manager ins;
    private int point = 0;
    [SerializeField] int maxPoint;
    public bool isEndGame;
    private void Start()
    {
        ins = this;
    }

    public void UpdatePoint()
    {
        point++;
        if(point == maxPoint)
        {
            UIManager_Scene1_3.ins.ActiveFingerScaning();
        }
    }


    public void CompleteScene()
    {
        isEndGame = true;
        //Load new Scene

        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".2");
    }

    public int GetPoint()
    {
        return point;
    }
}
