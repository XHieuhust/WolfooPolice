using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene24Manager : MonoBehaviour
{
    public static GameScene24Manager ins;
    public int point;
    [SerializeField] int maxPoint;
    [SerializeField] public Police_SceneBank police;
    [SerializeField] SpawnCriminal_SceneBank spawnManager;
    [SerializeField] int pointUpLevel;
    private void Awake()
    {
        ins = this;
    }

    public void UpdatePoint()
    {
        point++;
        if (point == pointUpLevel)
        {
            spawnManager.StartSpawnCriminalGun();
        }
        if(point == maxPoint)
        {
            LoadNewScene();
        }
    }

    private void LoadNewScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(newScene + ".5");
    }
}
