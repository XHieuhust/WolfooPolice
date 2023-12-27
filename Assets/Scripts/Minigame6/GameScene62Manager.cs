using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene62Manager : MonoBehaviour
{
    public static GameScene62Manager ins;

    public bool isStartGame;
    public bool isEndGame;
    [SerializeField] public WolfooMinigame6 wolfoo;
    [SerializeField] GameObject limitScene;

    public Transform endPos;
    private void Awake()
    {
        ins = this;
        // Get Length Move
        limitScene.transform.position = new Vector3(endPos.position.x - Camera.main.orthographicSize * Camera.main.aspect, limitScene.transform.position.y, limitScene.transform.position.z);
    }

    public void LoadNewScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");

        ScenesManager.ins.LoadScene(newScene + ".3");

    }

    public void StartGame()
    {
        isStartGame = true;
    }
}
