using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMeneManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;

    private void Awake()
    {
        button1.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene1");
            ScenesManager.ins.LoadScene("Scene1.1");
        });

        button2.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene2");
            ScenesManager.ins.LoadScene("Scene2.1");
        });
    }
}
