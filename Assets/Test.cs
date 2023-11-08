using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Test : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Jump", false).Complete += Test_Complete;
    }

    private void Test_Complete(Spine.TrackEntry trackEntry)
    {
        skeleton.initialSkinName = "Police";
        skeleton.Initialize(true);
    }
}
