using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInstance : MonoBehaviour
{
    public static CanvasInstance ins;

    private void Awake()
    {
        ins = this;
    }
}
