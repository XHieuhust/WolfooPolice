using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene5Manager : MonoBehaviour
{
    public static GameScene5Manager ins;
    [SerializeField] ShadeBg shade;

    public int vpAnDuoc;
    [SerializeField] public GameObject tuiSao;
    [SerializeField] public GameObject bar;
    [SerializeField] public int completeVp;
    [SerializeField] public Player player;
    [SerializeField] public Thief thief;
    [SerializeField] public OtherPoliceScene15 otherPolice;
    public bool isPlayEndScene;




    public void UpdateVpAnDuoc()
    {
        vpAnDuoc++;
        if (vpAnDuoc == (completeVp - 5))
        {
            PlayEndScene();
        }
    }

    void PlayEndScene()
    {
        SpawnThings.ins.StopToSpawn();
        SpawnThings.ins.isCanSpawn = false;

        StartCoroutine(WaitToPlayEndScene());

    }

    IEnumerator WaitToPlayEndScene()
    {
        yield return new WaitForSeconds(6);
        isPlayEndScene = true;
        thief.EndScene();
        player.EndScene();
        otherPolice.gameObject.SetActive(true);
        otherPolice.EndScene();
        yield return new WaitForSeconds(2.5f);
        GameManager.ins.CompleteMap();
        ScenesManager.ins.LoadScene("SceneMenu");
    }


}
