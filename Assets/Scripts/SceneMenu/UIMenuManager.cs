using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMenuManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    [SerializeField] Button button8;

    private void Awake()
    {
        button1.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene1");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });

        button2.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene2");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });

        button3.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene3");
            PlayerPrefs.SetInt("curScene", 0);

            PlayMinigame();

        });
/*        button4.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene4");
            PlayMinigame();
        });*/
        button5.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene5");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });
        button6.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene6");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });
        button7.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene7");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });
        button8.onClick.AddListener(delegate
        {
            PlayerPrefs.SetString("curMinigame", "Scene8");
            PlayerPrefs.SetInt("curScene", 1);

            PlayMinigame();
        });

    }


    private void PlayMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene");
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());

    }
}
