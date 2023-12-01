using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Police_Scene2_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation wolfoo;
    [SerializeField] SkeletonAnimation kat;


    public void Move(float seconds)
    {
        StartCoroutine(StartMove(seconds));
    }
    IEnumerator StartMove(float seconds)
    {
        transform.position = new Vector3(GameScene12Manager.ins.car.transform.position.x + 2f, transform.position.y, transform.position.z);

        wolfoo.AnimationState.SetAnimation(0, "Run_Ninja2", true);
        kat.AnimationState.SetAnimation(0, "Run_Ninja2", true);
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Vector3 endPosition = new Vector3(GameScene12Manager.ins.endPosition.position.x + 1.5f, transform.position.y, transform.position.z);
        while (elapsedTime <= seconds)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds)); ;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPosition;
        wolfoo.AnimationState.SetAnimation(0, "Idle_Talk", true);
        kat.AnimationState.SetAnimation(0, "Idle_Talk", true);
        GameScene12Manager.ins.shopKeeper.Idle_Talk();
    }



}
