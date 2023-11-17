using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour
{
    LineRenderer waterRay;
    [SerializeField] Transform startRay;
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
    private void Start()
    {
        waterRay = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        Vector3 start = new Vector3(startRay.position.x, startRay.position.y, -1);
        waterRay.SetPosition(0, start);
        if (ToolManager.ins.isStartTurn)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direct = (posMouse - transform.position).normalized;
                float rotateZ = Vector2.Angle(direct, Vector2.up);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotateZ);

                Vector3 end = new Vector3(posMouse.x, posMouse.y, -1);
                waterRay.SetPosition(1, end);
            }
            else
            {
                waterRay.SetPosition(1, start);
            }
        }
        else
        {
            waterRay.enabled = false;
        }

    }

}
