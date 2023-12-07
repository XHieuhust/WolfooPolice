using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager_Scene2_2 : MonoBehaviour
{
    [SerializeField] Police_Scene2_2 wolfoo;
    [SerializeField] Police_Scene2_2 kat;
    
    public void StartScene(float seconds)
    {
        wolfoo.MoveRight(seconds, false);
        kat.MoveRight(seconds, true);
    }

    public void StartTurn()
    {
        wolfoo.StartTurn();
        kat.StartTurn();
    }
}
