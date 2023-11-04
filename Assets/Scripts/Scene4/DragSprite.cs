using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSprite : MonoBehaviour
{
    Vector3 scaleNormal;
    [SerializeField] GameObject trueObject;
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
        if (isbeingHeld && transform.position != trueObject.transform.position)
        {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {   
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = trueObject.transform.localScale;
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        if(Mathf.Sqrt((transform.position.x - trueObject.transform.position.x) * (transform.position.x - trueObject.transform.position.x) + 
            (transform.position.y - trueObject.transform.position.y) * (transform.position.x - trueObject.transform.position.x)) < minDist)
        {
            transform.position = trueObject.transform.position;
            QuanLyCacBoPhan.ins.UpdateCntTrueBoPhan();
            Destroy(trueObject);
        }else
        {   
            StartCoroutine(StartToMoveBack());
        }
        
    }

    IEnumerator StartToMoveBack()
    {
        transform.localScale = scaleNormal;
        float speedMoveBack = 50f;
        Vector2 newPosition;
        while (transform.position != startPos)
        {
            newPosition = Vector2.MoveTowards(transform.position, startPos, speedMoveBack * Time.deltaTime);
            transform.position = newPosition;
            yield return new WaitForEndOfFrame();
        }
    }

}
