using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoverShadeWhite : MonoBehaviour
{
    Image image;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = FindObjectOfType<Canvas>();
        rectTransform.localScale = new Vector3(canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width),
        canvas.GetComponent<RectTransform>().rect.height / (rectTransform.rect.height));

        transform.position = new Vector3(0, 0, transform.position.z);
        image = GetComponent<Image>();
        image.color = new Color(255, 255, 255, 0);
          
    }

    public void IncreaseShade(float seconds)
    {
        StartCoroutine(StartIncreaseShade(seconds));
    }
    IEnumerator StartIncreaseShade(float seconds)
    {
        float eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            image.color = new Color(255, 255, 255, 1 * (eslapsed / seconds));
            yield return new WaitForEndOfFrame();
        }
        image.color = new Color(255, 255, 255, 1);
    }
}
