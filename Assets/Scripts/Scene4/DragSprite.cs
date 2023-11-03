using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    Vector3 scaleNormal;
    [SerializeField] Transform TruePosition;
    private Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;
    private void Start()
    {
        startPos = transform.position;
        scaleNormal = transform.localScale;
    }

    private void Update()
    {
        if (isbeingHeld && transform.position != TruePosition.position)
        {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {   
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = new Vector3(scaleNormal.x * 1.2f, scaleNormal.y * 1.2f, scaleNormal.z * 1.2f);
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        if(Mathf.Sqrt((transform.position.x - TruePosition.position.x) * (transform.position.x - TruePosition.position.x) + 
            (transform.position.y - TruePosition.position.y) * (transform.position.x - TruePosition.position.x)) < minDist)
        {
            transform.position = TruePosition.position;
            RoundManager.ins.completedDrag++;
            // Load NextScene
            if(RoundManager.ins.completedDrag == 3)
            {
                StartCoroutine(StartToLoadNextScene());
            }
        }
        else
        {
            StartCoroutine(StartToMoveBack());
        }
        transform.localScale = scaleNormal;
    }

    IEnumerator StartToMoveBack()
    {
        float speedMoveBack = 10f;
        Vector2 newPosition;
        while (transform.position != startPos)
        {
            newPosition = Vector2.MoveTowards(transform.position, startPos, speedMoveBack * Time.deltaTime);
            transform.position = newPosition;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator StartToLoadNextScene()
    {
        yield return new WaitForSeconds(1);
        ScenesManager.ins.LoadScene("Scene5");
    }
}
