using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Screen : MonoBehaviour
{
    [SerializeField] Image imageMap;
    [SerializeField] GameObject lightNormal;
    [SerializeField] SkeletonGraphic lightAnim;

    public void TurnOnTheLight()
    {
        imageMap.gameObject.SetActive(true);
        lightNormal.SetActive(false);
        lightAnim.gameObject.SetActive(true);
        lightAnim.AnimationState.SetAnimation(0, "Idle", false).Complete += Screen_Complete;
    }

    private void Screen_Complete(Spine.TrackEntry trackEntry)
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(newScene+".2");
    }
}

