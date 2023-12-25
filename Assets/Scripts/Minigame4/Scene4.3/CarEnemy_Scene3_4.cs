using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy_Scene3_4 : MonoBehaviour
{
    [SerializeField] protected SkeletonAnimation skeleton;
    [SerializeField] protected float speed;
    protected Rigidbody2D rigid;
    
    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    protected void FixedUpdate()
    {
        MoveX();
    }
    protected void MoveX()
    {
        if (GameScene43Manager.ins.isStartGame)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
    }

    public void SetUp(string skin)
    {
        skeleton.initialSkinName = skin;
        skeleton.Initialize(true);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

    }
}
