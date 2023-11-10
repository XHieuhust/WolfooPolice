using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnQuet : MonoBehaviour
{
    bool isCliked;
    [SerializeField] GameObject mayQuetVanTay;
    private void OnMouseDown()
    {
        if (!isCliked)
        {
            isCliked = true;
            mayQuetVanTay.SetActive(true);
        }
    }
}
