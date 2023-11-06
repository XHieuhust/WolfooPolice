using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DragSprite : MonoBehaviour
{
    bool isCorrectDrag;
    protected Vector3 scaleNormal;
    [SerializeField] protected List<GameObject>ListTrueObjects;
    protected GameObject firstTrueObject;
    public Vector3 startPos;
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
        if (isbeingHeld && !isCorrectDrag)
        {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            ChangeScale();
        }
    }

    public virtual void ChangeScale() { }

    private void OnMouseDown()
    {
        if (!isCorrectDrag)
        {
            isbeingHeld = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localScale = ListTrueObjects[0].transform.localScale;
            if (transform.parent)
            {
                offset -= transform.parent.position;
            }

        }
    }

    public void OnMouseUp()
    {
        isbeingHeld = false;
        if (!isCorrectDrag)
        {
            foreach(GameObject ob in ListTrueObjects)
            {
                if(ThoaManDistance(gameObject, ob) && CheckTrangPhucDaDuocMac(ob))
                {
                    firstTrueObject = ob;
                    CorrectDrag();
                    break;
                }
            }
            if(!isCorrectDrag) StartCoroutine(StartToMoveBack());
        }   
    }

    bool ThoaManDistance(GameObject ob1, GameObject ob2)
    {
        if (ob2 != null)
        {
            if (Mathf.Sqrt((ob1.transform.position.x - ob2.transform.position.x) * (ob1.transform.position.x - ob2.transform.position.x) +
             (ob1.transform.position.y - ob2.transform.position.y) * (ob1.transform.position.y - ob2.transform.position.y)) < minDist)
            {
                return true;
            }
        }
        return false;
    }


    public virtual void CorrectDrag()
    {
        isCorrectDrag = true;
        transform.position = firstTrueObject.transform.position;
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

    bool CheckTrangPhucDaDuocMac(GameObject ob)
    {
        if (QuanLyPolice.ins)
            return (!QuanLyPolice.ins.CheckPoliceDaMacDo(ob));
        return true;
    }

}
