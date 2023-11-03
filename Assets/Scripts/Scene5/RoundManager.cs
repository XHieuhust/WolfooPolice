using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public bool isPlayerbeHitted;
    public static RoundManager ins;
    public int completedDrag;
    public int VpAnDuoc;
    private void Start()
    {
        ins = this;
    }



}
