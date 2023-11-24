using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalScene72 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] Transform posSpawn;

    [SerializeField] BannedItem item;

    private void Start()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c2", true);
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
        StartCoroutine(nameof(StartSpawn));
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Instantiate(item, posSpawn.transform.position, Quaternion.identity);
            skeleton.AnimationState.SetAnimation(1, "Angry", false).Complete += CriminalScene72_Complete;
            yield return new WaitForSeconds(item.seconds);
        }
    }

    private void CriminalScene72_Complete(Spine.TrackEntry trackEntry)
    {
        skeleton.AnimationState.SetAnimation(1, "Idle", false);
    }
}
