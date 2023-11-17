using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager ins;
    [SerializeField] Bubble bubble;
    [SerializeField] Towel towel;
    [SerializeField] WaterTap waterTap;
    [SerializeField] ShowerHead showerHead;
    public bool isStartTurn = true;

    private void Start()
    {
        ins = this;
    }
    public void StartBubble()
    {
        StartCoroutine(MoveRightAndStartNextTurn(waterTap.gameObject, bubble.gameObject));
    }

    public void StartShower()
    {
        StartCoroutine(MoveRightAndStartNextTurn(bubble.gameObject, showerHead.gameObject));
    }

    public void StartTowel()
    {
        StartCoroutine(MoveUpAndStartNextTurn(showerHead.gameObject, towel.gameObject));
    }

    IEnumerator MoveUpAndStartNextTurn(GameObject dis, GameObject ena)
    {
        isStartTurn = false;
        Vector3 startPos = dis.transform.position;
        Vector3 endPos = dis.transform.position + new Vector3(0, 5f, 0);
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dis.transform.position = Vector3.Lerp(startPos, endPos, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        dis.transform.position = endPos;
        dis.SetActive(false);   
        ena.SetActive(true);
        isStartTurn = true;
    }

    IEnumerator MoveRightAndStartNextTurn(GameObject dis, GameObject ena)
    {
        isStartTurn = false;
        Vector3 startPos = dis.transform.position;
        Vector3 endPos = dis.transform.position + new Vector3(5f, 0f, 0);
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dis.transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        dis.transform.position = endPos;
        dis.SetActive(false);
        ena.SetActive(true);
        isStartTurn = true;
    }
}
