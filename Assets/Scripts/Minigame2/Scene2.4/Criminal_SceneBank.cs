using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal_SceneBank : MonoBehaviour
{
    [SerializeField] protected float speedMove;
    public float directX;
    [SerializeField] protected SkeletonAnimation skeleton;
    protected bool isBeShooted;
    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Walk_CarryMoney", true);
    }

    protected void Update()
    {
        Move();
    }


    protected virtual void Move()
    {
        if (!isBeShooted)
        {
            transform.position += new Vector3(directX * speedMove * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, (directX == -1) ? 0 : 180);
        }


    }

    public void BeShooted()
    {
        if (!isBeShooted)
        {
            StartCoroutine(StartBeShooted());
        }
    }

    IEnumerator StartBeShooted()
    {
        isBeShooted = true;
        SetAnimGetHurt();
        float eslasped = 0;
        float seconds = 1f;

        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            skeleton.Skeleton.A = (1 - eslasped / seconds);
            yield return new WaitForEndOfFrame();
        }
        skeleton.Skeleton.A = 0;
        Destroy(gameObject);
    }

    protected virtual void SetAnimGetHurt()
    {
        skeleton.AnimationState.SetAnimation(0, "Sit_GethurtMonney", true);
    }

    public void IncreaseOrderLayer()
    {
        skeleton.gameObject.GetComponent<MeshRenderer>().sortingOrder += 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitScene"))
        {
            Destroy(gameObject);
        }
    }
}
