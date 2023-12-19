using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class MomKid : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    public void HugeTheKid()
    {
        skeleton.AnimationState.SetAnimation(0, "Kneel", true);
    }
}
