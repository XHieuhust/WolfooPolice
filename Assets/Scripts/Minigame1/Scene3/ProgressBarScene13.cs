using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarScene13 : MonoBehaviour
{
    RectTransform rectBar;
    [SerializeField] float speed;
    private void Start()
    {
        rectBar = GetComponent<RectTransform>();
    }

    public void UpdateBar(float newScaleX)
    {
        StartCoroutine(ProgressUpdateBar(newScaleX));
    }

    IEnumerator ProgressUpdateBar(float newScaleX)
    {
        while(rectBar.localScale.x <= newScaleX)
        {
            rectBar.localScale += new Vector3(speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        rectBar.localScale = new Vector3(newScaleX, rectBar.localScale.y, rectBar.localScale.z);
    }
}
