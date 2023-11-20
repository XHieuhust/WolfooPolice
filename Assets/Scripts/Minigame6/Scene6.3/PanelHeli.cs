using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHeli : MonoBehaviour
{
    public static PanelHeli ins;
    [SerializeField] Button circleLight;
   
    private void Awake()
    {
        ins = this;
    }


}
