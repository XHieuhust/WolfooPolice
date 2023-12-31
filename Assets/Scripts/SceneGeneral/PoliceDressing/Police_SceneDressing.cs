using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_SceneDressing : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    public bool isEquipped;
    int cntEquip;
    bool isRightPos; //tmp change skin
    public void MoveRight(float seconds, bool isRight)
    {
        isRightPos = isRight;
        StartCoroutine(StartMoveRight(seconds, isRight));
    }

    IEnumerator StartMoveRight(float seconds, bool isRight)
    {
        Vector3 startPos = transform.position;
        Vector3 end = startPos;
        Vector3 start = startPos - new Vector3(2 * Camera.main.orthographicSize * Camera.main.aspect, 0, 0);

        transform.eulerAngles = new Vector3(0, 180, 0);
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);

        float eslapsed = 0;

        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }

    public void EquipTheDevice()
    {

        StopCoroutine(nameof(StartEquip));
        StartCoroutine(nameof(StartEquip));

    }

    IEnumerator StartEquip()
    {
        isEquipped = true;
        cntEquip++;

        string SceneSkin = null;
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        if (curMinigame == "Scene2")
        {
            SceneSkin = "Swat";
        }else
        {
            if (isRightPos)
            {
                SceneSkin = "TrafficPoliceman";
            }
            else
            {
                SceneSkin = "TraficPoliceman";
            }
        }

        
        skeleton.initialSkinName = SceneSkin + (cntEquip).ToString();
        skeleton.Initialize(true);
        skeleton.AnimationState.SetAnimation(0, "Dressing" + (cntEquip).ToString(), true);

        yield return new WaitForSeconds(1);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

    }

    public void StartTurn()
    {
        isEquipped = false;
    }

    public void EndScene(float seconds)
    {
        StopAllCoroutines();
        StartCoroutine(StartEndScene(seconds));
    }

    IEnumerator StartEndScene(float seconds)
    {
        float eslapsed = 0;
        transform.eulerAngles = new Vector3(0, 180, 0);
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(2 * Camera.main.orthographicSize * Camera.main.aspect, 0, 0);

        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
