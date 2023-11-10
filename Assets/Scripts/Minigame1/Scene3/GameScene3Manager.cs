using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene3Manager : MonoBehaviour
{
    public static GameScene3Manager ins;
    [SerializeField] GameObject BarProgress;
    int maxTurn = 3;
    public int cntCompleteTurn;
    private void Start()
    {
        ins = this;
    }

    public void UpdateCntCompleteTurn()
    {
        cntCompleteTurn++;
        BarProgress.GetComponent<ProgressBarScene13>().UpdateBar(1f * cntCompleteTurn / maxTurn);
        if (cntCompleteTurn == maxTurn)
        {
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.4f);
        ScenesManager.ins.LoadScene("Scene1.4");
    }
}
