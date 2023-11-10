using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarScene25 : MonoBehaviour
{
    [SerializeField] float speed;

    public void UpdateBar(float newScaleX)
    {
        StartCoroutine(ProgressUpdateBar(newScaleX));
    }

    IEnumerator ProgressUpdateBar(float newScaleX)
    {
        while (transform.localScale.x <= newScaleX)
        {
            transform.localScale += new Vector3(speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
    }
}
