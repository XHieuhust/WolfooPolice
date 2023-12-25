using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene43Manager : MonoBehaviour
{
    public static GameScene43Manager ins;

    public bool isStartGame;
    private void Awake()
    {
        ins = this;
    }
}
