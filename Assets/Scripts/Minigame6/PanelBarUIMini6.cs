using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBarUIMini6 : MonoBehaviour
{
    public static PanelBarUIMini6 ins;
    [SerializeField] Image barFill;
    [SerializeField] Image WolfIcon;
    [SerializeField] Image RihinoIcon;

    Vector3 startPosWolfIcon;

    private float lengthBar;

    private void Start()
    {
        ins = this;
        lengthBar = RihinoIcon.transform.position.x - WolfIcon.transform.position.x;
        startPosWolfIcon = WolfIcon.transform.position;
    }


    public void UpdateBar(float rate)
    {
        if (rate >= 0)
        {
            WolfIcon.transform.position = startPosWolfIcon + new Vector3(rate * lengthBar, 0, 0);
            barFill.fillAmount = rate;
        }

    }

}
