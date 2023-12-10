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
        StartGame();

    }


    public void SetAnimCry()
    {
        skeleton.AnimationState.SetAnimation(0, "Scare", true);
    }

    private void StartGame()
    {
        StartCoroutine(MoveToStartGame());
    }

    IEnumerator MoveToStartGame()
    {
        float endX = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 0.5f;

        while (transform.position.x <= endX)
        {
            rigid.velocity = Vector2.right * speed;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos.position;
        rigid.velocity = Vector2.zero;
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        GameScene62Manager.ins.isStartGame = true;
    }
}
