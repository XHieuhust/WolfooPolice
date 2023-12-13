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
    [SerializeField] ShadeBg endShade;
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

    public void CompleteScanning()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(4f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNewScene(); 
    }

    private void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".2");
    }
}
