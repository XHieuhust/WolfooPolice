using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene25Manager : MonoBehaviour
{
    public static GameScene25Manager ins;
    public delegate void StartTurn(float time);
    public static event StartTurn startTurn;
    [SerializeField] float timeStartTurn;
    [SerializeField] int maxPoint;
    [SerializeField] int madPoint;
    int curPoint;
    [SerializeField] Criminal_Scene5_2 criminal;
    private void Awake()
    {
        ins = this;
    }

    public void StartNewTurn()
    {
        startTurn?.Invoke(timeStartTurn);
    }

    public void UpdatePoint()
    {
        curPoint++;
        if (curPoint % madPoint == 0)
        {
            criminal.GetMad();
        }
    }
}
