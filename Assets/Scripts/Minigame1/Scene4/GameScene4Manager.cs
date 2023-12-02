using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene4Manager : MonoBehaviour
{
    public static GameScene4Manager ins;
    [SerializeField] ShadeBg shadeBg;

    private void Start()
    {
        ins = this;
    }

    public void EndScene()
    {
        StartCoroutine(StartToNextScene());
    }

    IEnumerator StartToNextScene()
    {
        shadeBg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        ScenesManager.ins.LoadScene("Scene1.5");
    }
}
