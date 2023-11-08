using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene24Manager : MonoBehaviour
{
    public static GameScene24Manager ins;
    [SerializeField] public GameObject police;
    private void Start()
    {
        ins = this;
    }
}
