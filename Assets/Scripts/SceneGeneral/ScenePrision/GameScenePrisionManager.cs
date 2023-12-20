using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenePrisionManager : MonoBehaviour
{
    public static GameScenePrisionManager ins;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;

    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }
}
