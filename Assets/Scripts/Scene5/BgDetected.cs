using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgDetected : MonoBehaviour
{
    RectTransform rectTransform;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(Camera.main.pixelWidth / rectTransform.sizeDelta.x,
           Camera.main.pixelWidth / rectTransform.sizeDelta.x);
    }
}
