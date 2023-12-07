using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneDressingManager : MonoBehaviour
{
    public static GameSceneDressingManager ins;
    [SerializeField] PoliceManager_SceneDressing policeManager;
    [SerializeField] RopeManager_SceneDressing ropeManager;
    public int cntTurn;
    public int maxTurn;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;

    private void Awake()
    {
        ins = this;
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        startShade.gameObject.SetActive(true);
        policeManager.StartScene(2f);
        yield return new WaitForSeconds(2f);
        ropeManager.StartTurn();
    }

    public void UpdateTurn()
    {
        cntTurn++;
        if (cntTurn == maxTurn)
        {
            EndScene();
        }
        else
        {
            ropeManager.StartTurn();
            policeManager.StartTurn();
        }

    }

    private void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
        policeManager.EndScene(2f);
        endShade.gameObject.SetActive(true);

    }
}
