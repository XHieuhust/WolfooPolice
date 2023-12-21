using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public static FPS ins;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        ins = this;
        // Make the game run as fast as possible
        Application.targetFrameRate = -1;
        // Limit the framerate to 90
        Application.targetFrameRate = 120;
    }

}
