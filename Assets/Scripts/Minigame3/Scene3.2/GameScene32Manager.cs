using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene32Manager: MonoBehaviour
{
    public static GameScene32Manager ins;
    public bool isMovingCam;
    [SerializeField] ShadeBg startShade;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void CompleteMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
