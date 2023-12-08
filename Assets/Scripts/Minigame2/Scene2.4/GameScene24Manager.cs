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
    [SerializeField] int pointAppearCriminalGun;
    private bool isEndGame;
    public delegate void EndScene();
    public event EndScene endScene;

    private void Awake()
    {
        ins = this;
    }

    public void UpdatePoint()
    {
        if (!isEndGame)
        {
            point++;
            BarPanel_SceneBank.ins.UpdateBar(1.0f * point / maxPoint);
            if (point == pointAppearCriminalGun)
            {
                spawnManager.StartSpawnCriminalGun();
            }
            if (point == maxPoint)
            {
                isEndGame = true;
                StartCoroutine(StartEndScene());
            }
        }

    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
        endScene?.Invoke();
        yield return new WaitForSeconds(2f);
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(newScene + ".5");
    }
}
