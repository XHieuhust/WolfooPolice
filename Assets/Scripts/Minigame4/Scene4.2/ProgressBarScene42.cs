using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScene42 : MonoBehaviour
{
    Image bar;
    [SerializeField] Image icon;
    [SerializeField] float lengthBar;
    float startPosYIcon;
    RectTransform rectIcon;
    private void Start()
    {
        bar = GetComponent<Image>();
        rectIcon = icon.GetComponent<RectTransform>();
        startPosYIcon = rectIcon.anchoredPosition.y;
    }
    public void UpdateBarProgress(float rate)
    {
        rate = (rate >= 1) ? 1 : rate;    
        bar.fillAmount = rate;
        rectIcon.anchoredPosition = new Vector2(rectIcon.anchoredPosition.x, startPosYIcon + rate * lengthBar);
    }
}
