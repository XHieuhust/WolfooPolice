using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToys : MonoBehaviour
{
    protected Vector3 scaleNormal;
    public Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;
    [SerializeField] GameObject truePos;

    private void Start()
    {
        startPos = transform.position;
        scaleNormal = transform.localScale;
    }
    private void Update()
    {
        if (isbeingHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = new Vector3(scaleNormal.x * 1.2f, scaleNormal.y * 1.2f, scaleNormal.z * 1.2f);
        transform.SetAsLastSibling();
    }

    public void OnMouseUp()
    {
        transform.localScale = scaleNormal;
        isbeingHeld = false;
        if (Vector2.Distance(transform.position, truePos.transform.position) <= minDist)
        {
            GameScene31Manager.ins.UpdatePoint();
            Destroy(gameObject);
        }
        StartCoroutine(StartToMoveBack());
    }

    IEnumerator StartToMoveBack()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;

    }

}
