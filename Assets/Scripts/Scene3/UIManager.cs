using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    private void Start()
    {
        ins = this;
        //gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    IEnumerator StartToLoadNextScene()
    {
        yield return new WaitForSeconds(1);
        ScenesManager.ins.LoadScene("Scene4");
    }

}
