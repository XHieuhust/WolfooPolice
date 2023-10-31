using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager ins;
    void Start()
    {
        ins = this;
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
