using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene12Manager : MonoBehaviour
{
    public static GameScene12Manager ins;
    [SerializeField] public GameObject road;
    [SerializeField] GameObject wolfooNam;
    [SerializeField] GameObject car;
    public Transform endPosition;
    private void Awake()
    {
        ins = this;
    }
    public void EndGame()
    {
        wolfooNam.SetActive(true);
    }

    public void LoadNextScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        if (newScene.Equals("Scene1"))
        {
            ScenesManager.ins.LoadScene("Scene1.3");
        }
        else
        {
            ScenesManager.ins.LoadScene("Scene2.4");
        }
    }
}
