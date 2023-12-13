using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleKids : MonoBehaviour
{
    RectTransform rect;
    float startScale;
    Image bubbleImage;
    int curBg;
    Vector3 startPos;
    [SerializeField] List<Sprite> spriteBubbles;
    [SerializeField] Transform posHint;
    Vector3 pivot1;
    Vector3 pivot2;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        bubbleImage = GetComponent<Image>();
        startScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        startPos = transform.position;
        pivot1 = rect.pivot;
        pivot2 = new Vector3(1, 0.5f);
    }

    private void OnEnable()
    {
        CameraSet.camMove += BubbleUpdatePosHint;
        CameraSet.camMoveIntro += ScaleUp;
    }

    private void OnDestroy()
    {
        CameraSet.camMove -= BubbleUpdatePosHint;
        CameraSet.camMoveIntro -= ScaleUp;
    }

    private void ScaleUp()
    {
        StartCoroutine(StartScaleUp());
    }

    IEnumerator StartScaleUp()
    {
        //rect.pivot = pivot1;
        float eslapsed = 0;
        float seconds = 0.5f;
        transform.position = startPos;
        float end = startScale;
        bubbleImage.sprite = spriteBubbles[0];
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.localScale = new Vector3(eslapsed/seconds * end, eslapsed/seconds * end, eslapsed/seconds * end);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(end, end, end);

    }

    private void BubbleUpdatePosHint()
    {
        if (curBg < 3)
        {
            rect.pivot = pivot2;
            Vector3 newPosHint = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect - 0.1f, posHint.position.y, posHint.position.z);
            transform.position = newPosHint;
            bubbleImage.sprite = spriteBubbles[1];
            curBg++;
            
        }
        else
        {
            ScaleUp();
        }
    }
}
