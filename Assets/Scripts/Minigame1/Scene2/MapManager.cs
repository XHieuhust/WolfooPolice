using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ListMap;
    private int numOfMap;
    public static MapManager ins;
    void Start()
    {
        ins = this;
        numOfMap = ListMap.Count;
        LoadMap();
    }

    public void LoadMap()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        Instantiate(ListMap[curLevel % numOfMap], transform.position, Quaternion.identity);
    }
}
