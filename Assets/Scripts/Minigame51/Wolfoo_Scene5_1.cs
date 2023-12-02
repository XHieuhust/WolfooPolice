using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Wolfoo_Scene5_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] Transform posStartScene;
    void Awake()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
    }

    public void MoveToStartScene(float seconds)
    {
        StartCoroutine(StartMoveToPosStartScene(seconds));
    }

    IEnumerator StartMoveToPosStartScene(float seconds)
    {
        Vector3 start = transform.position;
        Vector3 end = posStartScene.position;

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        skeleton.AnimationState.SetAnimation(0, "Run_Ninja2", true);
    }
}
