using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene72Manager : MonoBehaviour
{
    public static GameScene72Manager ins;
    [SerializeField] public DogScene72 dog;
    private void Awake()
    {
        ins = this;
    }


}
