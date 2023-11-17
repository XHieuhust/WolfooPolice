using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;

    private void OnEnable()
    {
        StartCoroutine(MoveToStartPos());
    }

    IEnumerator MoveToStartPos()
    {
        Vector3 startPos = transform.position + new Vector3(5f, 0, 0);
        Vector3 endPos = transform.position;
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos;
    }

    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (transform.parent)
        //{
        //    offset -= transform.parent.position;
        //}
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
    }
}
