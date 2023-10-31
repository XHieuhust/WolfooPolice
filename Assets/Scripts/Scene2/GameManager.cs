using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Map1;
    [SerializeField] GameObject Map2;

    static GameManager ins;
    void Start()
    {
        ins = this;

        int ran = Random.Range(1, 3);
        if(ran == 1)
        {
            Instantiate(Map1, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Map2, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }



}
