using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Map1;
    [SerializeField] GameObject Map2;
    [SerializeField] GameObject Map3;

    public static GameManager ins;
    void Start()
    {
        ins = this;
    }



}
