using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class WolfBanTocDo : MonoBehaviour
{
    [SerializeField] SkeletonGraphic skeWolfoo;

    [SerializeField] List<Sprite> ListNoticeBoards;
    [SerializeField] Image notice;
    [SerializeField] Image posNotice;
    [SerializeField] MayBanTocDo mayBanToc;


    public void Notice(bool isIllegal, Transform EnemyCar)
    {
        Image newNotice = Instantiate(notice, posNotice.transform.position, Quaternion.identity, transform);
        if (!isIllegal)
        {
            newNotice.sprite = ListNoticeBoards[0];
        }
        else
        {
            newNotice.sprite = ListNoticeBoards[1];
        }
        mayBanToc.UpdateEndLine(EnemyCar);
    }

    public void JumpHigh()
    {
        skeWolfoo.AnimationState.SetAnimation(0, "Jump_Hight", true);
    }
}
