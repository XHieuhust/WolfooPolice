using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevicePolice : MonoBehaviour
{
    private Vector3 scaleNormal;
    private Vector3 startPos;
    bool isbeingHeld = false;
    private Vector3 offset;
    [SerializeField] float minDist;
    private bool isCanDrag;
    Police_Scene2_2 police;
    [SerializeField] Rope_Scene2_2 rope;
    private void Start()
    {
        isCanDrag = true;
        startPos = rope.belowPos;
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
        if (isCanDrag)
        {
            isbeingHeld = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localScale = new Vector3(scaleNormal.x * 1.2f, scaleNormal.y * 1.2f, scaleNormal.z * 1.2f);
        }

    }

    public void OnMouseUp()
    {
        transform.localScale = scaleNormal;
        isbeingHeld = false;
        if (police != null)
        {
            if (Vector2.Distance(transform.position, police.transform.position) <= minDist)
            {
                if (!police.isEquipped)
                {
                    Destroy(gameObject);
                }
            }
        }
        StartCoroutine(StartToMoveBack());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            police = collision.gameObject.GetComponent<Police_Scene2_2>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            police = null;
        }
    }

    IEnumerator StartToMoveBack()
    {
        isCanDrag = false;
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
        isCanDrag = true;
    }
}
