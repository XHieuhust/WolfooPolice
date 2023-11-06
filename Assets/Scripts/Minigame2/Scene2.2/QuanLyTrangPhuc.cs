using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyTrangPhuc : MonoBehaviour
{
    [SerializeField] List<GameObject> ListTrangPhucs;
    [SerializeField] bool flipX;
    Vector3 startPos;
    Vector3 beHoldPosition;

    private void Awake()
    {
        startPos = transform.position;
        beHoldPosition = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize, transform.position.z);
        transform.position = beHoldPosition;
        StartCoroutine(MoveToStartPosition());
    }
    public void InstantinateTrangPhuc(int cnt)
    {
        GameObject trangPhuc = Instantiate(ListTrangPhucs[cnt], transform.position, Quaternion.identity);
        trangPhuc.GetComponent<SpriteRenderer>().flipX = flipX;
        trangPhuc.transform.SetParent(gameObject.transform, true);
        trangPhuc.GetComponent<TrangPhucCanhSat>().startPos = Vector3.zero;
    }

    public void DayMove()
    {

    }

    IEnumerator MoveToStartPosition()
    {
        float speedMove = 0.05f;
        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speedMove);
            yield return new WaitForEndOfFrame();
        }

    }
}
