using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class WolfooScene12 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation wolfAnim;

    IEnumerator StartMove()
    {
        wolfAnim.AnimationState.SetAnimation(0, "Run_ninja", true);
        float elapsedTime = 0;
        float seconds = 1f;
        Vector3 startingPos = transform.position;
        Vector3 endPosition = new Vector3(GameScene12Manager.ins.endPosition.position.x, transform.position.y);
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, endPosition, (elapsedTime / seconds)); ;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPosition;
        wolfAnim.AnimationState.SetAnimation(0, "Jump_Win", true).Complete += WolfooScene12_Complete;
    }

    private void WolfooScene12_Complete(Spine.TrackEntry trackEntry)
    {
        GameScene12Manager.ins.LoadNextScene();
    }

    private void OnEnable()
    {
        StartCoroutine(StartMove());
    }
}
