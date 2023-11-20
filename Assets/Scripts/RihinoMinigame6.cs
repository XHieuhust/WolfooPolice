using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class RihinoMinigame6 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] public Transform endPos;
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - endPos.position.x) > 0.1f && !GameScene62Manager.ins.isEndGame)
        {
            rigid.velocity = Vector2.right * speed;
        }

        if (transform.position.x >= Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 0.5f)
        {
            transform.position = endPos.position;
            rigid.velocity = Vector2.zero;
            skeleton.AnimationState.SetAnimation(0, "Idle", true);
            GameScene62Manager.ins.isStartGame = true;
        }
    }

    public void SetAnimCry()
    {
        skeleton.AnimationState.SetAnimation(0, "Scare", true);
    }
}
