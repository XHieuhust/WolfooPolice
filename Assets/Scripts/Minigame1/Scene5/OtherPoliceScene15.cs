using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class OtherPoliceScene15 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation anim;

    IEnumerator MoveToEndPosition()
    {
        float elapsedTime = 0;
        float seconds = 1f;
        Vector3 startingPos = transform.position;
        Vector3 endPos = new Vector3(+1.75f, transform.position.y, 0);
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        anim.AnimationState.SetAnimation(0, "Cheer", true);
        transform.position = endPos;

    }

    public void EndScene()
    {
        StartCoroutine(MoveToEndPosition());
    }
}
