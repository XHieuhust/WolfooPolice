using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Scene2_2 : MonoBehaviour
{
    public Vector3 belowPos;
    Vector3 abovePos;
    [SerializeField] List<DevicePolice> ListDevices;

    private void Awake()
    {
        belowPos = transform.position;
        abovePos = belowPos + new Vector3 (0, Camera.main.orthographicSize, 0);
        transform.position = abovePos;
    }

    public void MoveDown(float seconds)
    {
        StartCoroutine(StartMoveDown(seconds));
    }

    IEnumerator StartMoveDown(float seconds)
    {
        ListDevices[GameScene22tmpManager.ins.cntTurn].gameObject.SetActive(true);
        float eslapsed = 0;

        Vector3 start = abovePos;
        Vector3 end = belowPos;
        transform.position = start;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
