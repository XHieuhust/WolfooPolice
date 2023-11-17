using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
    Vector3 startPos;

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

    private void Awake()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            CleanWater();
        }
        
    }
    private void OnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        StartCoroutine(StartToMoveBack());
    }   

    void CleanWater()
    {
        if (Vector2.Distance(transform.position, GameScene51Manager.ins.car.transform.position) < 4f)
        {
            GameScene51Manager.ins.car.ClearWaterSprite();
        }
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
