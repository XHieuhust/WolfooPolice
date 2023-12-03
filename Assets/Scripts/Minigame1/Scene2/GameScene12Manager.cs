using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene12Manager : MonoBehaviour
{
    public static GameScene12Manager ins;
    [SerializeField] public GameObject road;
    [SerializeField] Police_Scene2_1 police;
    [SerializeField] public GameObject car;
    [SerializeField] public ShopKeeper shopKeeper;
    public Transform endPosition;
    public bool isEndGame;
    [SerializeField] GameObject coverShadeBg;
    private void Awake()
    {
        ins = this;
    }
    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

     
    IEnumerator StartEndScene()
    {
        police.gameObject.SetActive(true);
        police.Move(1.5f);
        yield return new WaitForSeconds(1.5f + 2f);
        coverShadeBg.SetActive(true);
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        if (newScene.Equals("Scene1"))
        {
            ScenesManager.ins.LoadScene(newScene + ".3");
        }
        else
        {
            ScenesManager.ins.LoadScene(newScene + ".4");
        }
    }
}
