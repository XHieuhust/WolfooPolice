using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int curMap = PlayerPrefs.GetInt("currentMap", 0);
        Instantiate(ListMap[curMap % numOfMap], Vector3.zero, Quaternion.identity);
    }
}
