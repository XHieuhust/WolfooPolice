using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene15Manager : MonoBehaviour
{
    [SerializeField] ShadeBg shade;
    public static GameScene15Manager ins;
    [SerializeField] Wolfoo_Scene5_1 wolfoo;
    [SerializeField] Criminal_Scene5_1 criminal;
    private void Start()
    {
        ins = this;
        StartCoroutine(StartScene());
    }



    IEnumerator StartScene()
    {
        shade.gameObject.SetActive(true);
        criminal.MoveToPosStartScene(2f);
        wolfoo.MoveToStartScene(1f);
        yield return new WaitForEndOfFrame();
    }
}
