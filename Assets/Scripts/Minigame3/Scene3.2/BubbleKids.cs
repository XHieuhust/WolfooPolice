using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleKids : MonoBehaviour
{
    float startScale;
    Image bubbleImage;
    Animator animator;
    int curBg;
    Vector3 startPos;
    [SerializeField] List<Sprite> spriteBubbles;
    [SerializeField] Transform posHint;
    private void Start()
    {
        bubbleImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
        startScale = transform.localScale.x;
        transform.localScale = Vector3.zero;
        startPos = transform.position;
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
        //animator.Play("Hint1");

    }

    private void BubbleUpdatePosHint()
    {
        if (curBg < 3)
        {
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
