using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police_Scene2_2 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    public bool isEquipped;
    public void MoveRight(float seconds, bool isRight)
    {
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
        isEquipped = true;
        StopCoroutine(nameof(StartEquip));
        StartCoroutine(nameof(StartEquip));
    }

    IEnumerator StartEquip()
    {
        int index = GameScene22tmpManager.ins.cntTurn;
        skeleton.Skeleton.SetSkin("Swat" + (index+1).ToString());
        skeleton.AnimationState.SetAnimation(0, "Dressing" + (index + 1).ToString(), true);

        yield return new WaitForSeconds(1.5f);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        
    }

    public void StartTurn()
    {
        isEquipped = false;
    }
}
