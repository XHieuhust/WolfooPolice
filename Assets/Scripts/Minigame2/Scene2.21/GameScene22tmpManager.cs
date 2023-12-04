using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene22tmpManager : MonoBehaviour
{
    public static GameScene22tmpManager ins;
    [SerializeField] PoliceManager_Scene2_2 policeManager;
    [SerializeField] RopeManager_Scene2_2 ropeManager;
    public int cntTurn;
    private void Awake()
    {
        ins = this;
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        policeManager.StartScene(2f);
        yield return new WaitForSeconds(2f);
        ropeManager.StartTurn(0.25f);

    }

    public void UpdateTurn()
    {
        cntTurn++;
        ropeManager.StartTurn(0.25f);
    }
}
