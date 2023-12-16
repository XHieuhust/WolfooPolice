using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene32Manager: MonoBehaviour
{
    public static GameScene32Manager ins;
    public bool isMovingCam;
    [SerializeField] ShadeBg startShade;
    public bool isEndgame;
    public delegate void End();
    public static event End end;

    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
        end?.Invoke();
        isEndgame = true;
        yield return new WaitForSeconds(2f);
        CompleteMinigame3();
    }

    private void CompleteMinigame3()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
