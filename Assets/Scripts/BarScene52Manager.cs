using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScene52Manager : MonoBehaviour
{

    [SerializeField] Image barFill;

    public void UpdateBarFill(float rate)
    {
        barFill.fillAmount = rate;
    }
}
