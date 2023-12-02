using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Criminal_Scene5_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] List<Transform> posMove;
    [SerializeField] float timeRandomMove;
    private void Awake()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);    
    }

    public void MoveToPosStartScene(float seconds)
    {
        StartCoroutine(StartMoveToPosStartScene(seconds));
    }
    IEnumerator StartMoveToPosStartScene(float seconds)
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);

        float eslapsed = 0;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    IEnumerator StartRandomMove()
    {
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        float eslapsed = 0;
        float seconds = 0.5f;
        float speedX = 20f;
        while (eslapsed <= seconds)
        {

        }
        yield return new WaitForEndOfFrame();
    }
}
