using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class WolfooAstray : MonoBehaviour
{
    [SerializeField] public SkeletonGraphic anim;

    public void Laugh()
    {
        StopCoroutine(nameof(StartLaugh));
        StartCoroutine(nameof(StartLaugh));
    }

    IEnumerator StartLaugh()
    {
        anim.AnimationState.SetAnimation(0, "Cheer", true);
        yield return new WaitForSeconds(1f);
        if(GameScene31Manager.ins.point < 3)
        {
            anim.AnimationState.SetAnimation(0, "Crying", true);    
        }
    }

    public void StartQuetVanTay()
    {
        StopAllCoroutines();
        anim.AnimationState.SetAnimation(0, "Idle", true);
    }
}
