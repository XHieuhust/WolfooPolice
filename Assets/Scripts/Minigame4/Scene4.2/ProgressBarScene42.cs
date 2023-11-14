using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScene42 : MonoBehaviour
{
    Image bar;
    [SerializeField] Image icon;
    float lengthBar;
    float startPosYIcon;
    private void Start()
    {
        bar = GetComponent<Image>();
        lengthBar = 2 * (transform.position.y - icon.transform.position.y);
        startPosYIcon = icon.transform.position.y;
    }
    public void UpdateBarProgress(int curPoint, int maxPoint)
    {
        float rate = 1.0f * curPoint / maxPoint;
        bar.fillAmount = rate;
        icon.transform.position = new Vector3(icon.transform.position.x, startPosYIcon + rate * lengthBar, icon.transform.position.z);
    }
}
