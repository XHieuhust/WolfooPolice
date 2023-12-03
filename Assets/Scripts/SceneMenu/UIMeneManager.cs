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
            PlayMinigame();
        });

        button2.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene2");
            PlayMinigame();
        });

    }


    private void PlayMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".1");

    }
}
