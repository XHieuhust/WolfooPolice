using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class WolfBanTocDo : MonoBehaviour
{
    [SerializeField] SkeletonGraphic skeWolfoo;

    [SerializeField] Image ray;

    [SerializeField] List<Sprite> ListNoticeBoards;
    [SerializeField] Image notice;
    [SerializeField] Image posNotice;
    [SerializeField] MayBanTocDo mayBanToc;


    public void Notice(bool isIllegal, Transform EnemyCar)
    {
        Instantiate(notice, posNotice.transform.position, Quaternion.identity, transform);
        if (isIllegal)
        {
            notice.sprite = ListNoticeBoards[0];
        }
        else
        {
            notice.sprite = ListNoticeBoards[1];
        }
        mayBanToc.UpdateEndLine(EnemyCar);
    }
}
