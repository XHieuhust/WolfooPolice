using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Screen_SceneCall : MonoBehaviour
{
    [SerializeField] Image imageMap;
    [SerializeField] GameObject lightNormal;
    [SerializeField] SkeletonGraphic lightAnim;
    [SerializeField] CoverShadeWhite shadeCover;
    public void TurnOnTheLight()
    {
        StartCoroutine(StartTurnOnTheLight());
    }

    private void LoadNextScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(newScene+".2");
    }

    IEnumerator StartTurnOnTheLight()
    {
        imageMap.gameObject.SetActive(true);
        lightNormal.SetActive(false);
        lightAnim.gameObject.SetActive(true);
        lightAnim.AnimationState.SetAnimation(0, "Idle", true);
        yield return new WaitForSeconds(2f);
        shadeCover.gameObject.SetActive(true);
        shadeCover.IncreaseShade(0.5f);
        yield return new WaitForSeconds(0.5f);
        LoadNextScene();
    }
}

