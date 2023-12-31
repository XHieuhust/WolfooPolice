using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class RihinoMinigame6 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;

    private void OnEnable()
    {
        WolfooMinigame6.eCatchUpWith += BeCatched;
    }

    private void OnDestroy()
    {
        WolfooMinigame6.eCatchUpWith -= BeCatched;

    }
    private void Start()
    {
        StartCoroutine(MoveToStartGame());
    }

    private void BeCatched()
    {
        skeleton.AnimationState.SetAnimation(0, "Scare", true);
    }

    IEnumerator MoveToStartGame()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);

        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 2f, transform.position.y, transform.position.z);

        float eslasped = 0;
        float seconds = 2.5f;
        skeleton.AnimationState.SetAnimation(0, "Run_c2", true);

        while (eslasped <= seconds)
        {
            eslasped += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslasped/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(GameScene62Manager.ins.endPos.position.x, transform.position.y, transform.position.z);

        skeleton.AnimationState.SetAnimation(0, "Idle", true);
    }
}
