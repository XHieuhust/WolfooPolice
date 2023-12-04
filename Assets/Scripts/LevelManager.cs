using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager ins;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        ins = this;
    }

    public void UpdateLevel(string Minigame)
    {
        int curLevel = PlayerPrefs.GetInt("Level" + Minigame, 0);
        PlayerPrefs.SetInt("Level" + Minigame, curLevel + 1);
    }

    public int GetLevel(string Minigame)
    {
        int curLevel = PlayerPrefs.GetInt("Level" + Minigame, 0);
        return curLevel;
    }
}
