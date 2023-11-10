using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToys : MonoBehaviour
{
    [SerializeField] RectTransform truePosition;
    protected Vector3 scaleNormal;
    public Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;

    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        startPos = rect.localPosition;
        scaleNormal = rect.localScale;
    }

    private void Update()
    {
        if (isbeingHeld)
        {
            rect.localPosition = Input.mousePosition + offset;
            rect.localScale = new Vector3(scaleNormal.x * 1.2f, scaleNormal.y * 1.2f);
        }
    }


    private void OnMouseDown()
    {
        isbeingHeld = true;
        rect.localPosition = Input.mousePosition;
        offset = rect.localPosition - Input.mousePosition;
        Debug.Log(Input.mousePosition);
    }


    public void OnMouseUp()
    {
        rect.localScale = scaleNormal;
        isbeingHeld = false;
        if (Vector2.Distance(rect.position, truePosition.position) <= minDist)
        {
            GameScene31Manager.ins.UpdatePoint();
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(StartToMoveBack());
        }
    }

    IEnumerator StartToMoveBack()
    {
        rect.localScale = scaleNormal;
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = rect.localPosition;
        while (elapsedTime < seconds)
        {
            rect.localPosition = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        rect.localPosition = startPos;
    }

}
