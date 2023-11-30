using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene86Manager : MonoBehaviour
{
    public static GameScene86Manager ins;
    [SerializeField] public Criminal_Scene6_8 criminal;
    public bool isEndGame;
    public bool isStartGame;
    private void Awake()
    {
        ins = this;
    }
}
