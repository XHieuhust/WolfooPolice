using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene62Manager : MonoBehaviour
{
    public static GameScene62Manager ins;

    public bool isStartGame;
    public bool isEndGame;
    [SerializeField] public RihinoMinigame6 rihino;
    [SerializeField] public WolfooMinigame6 wolfoo;
    private float lengthMove;
    private void Awake()
    {
        ins = this;
        // Get Length Move
        lengthMove = rihino.endPos.position.x - (Camera.main.orthographicSize * Camera.main.aspect * 2 / 3);
    }

    private void Update()
    {
        if (isStartGame && !isEndGame)
        {
            float tmp = wolfoo.transform.position.x - -(Camera.main.orthographicSize * Camera.main.aspect * 2 / 3);
            PanelBarUIMini6.ins.UpdateBar(tmp / lengthMove);
        }
    }

    public void LoadNewScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");

        ScenesManager.ins.LoadScene(newScene + ".3");

    }


}
