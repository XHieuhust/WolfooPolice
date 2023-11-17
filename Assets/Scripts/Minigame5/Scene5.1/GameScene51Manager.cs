using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene51Manager : MonoBehaviour
{
    public static GameScene51Manager ins;
    [SerializeField] public CarWash car;
    private void Start()
    {
        ins = this;
    }
}
