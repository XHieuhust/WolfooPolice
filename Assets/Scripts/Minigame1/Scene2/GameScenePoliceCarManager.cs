using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenePoliceCarManager : MonoBehaviour
{
    public static GameScenePoliceCarManager ins;
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
        police.Move(1.5f);
        yield return new WaitForSeconds(1.5f + 2f);
        coverShadeBg.SetActive(true);
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
