using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class Jangular : MonoBehaviour
{
    [SerializeField] public SkeletonGraphic skeleton;
    [SerializeField] CircleLight light;
    [SerializeField] private float minDist;
    public float lengthRoad;

    bool isMoving;

    [SerializeField] public BarProgressScene63 progressBar;
     
    private void Update()
    {
        RunAwayLight();
    }

    private void Start()
    {
        lengthRoad = Camera.main.orthographicSize * Camera.main.aspect - light.size/2;
        skeleton.AnimationState.SetAnimation(0, "Run_c", true);
    }
    private void RunAwayLight()
    {
        if (Vector2.Distance(transform.position, light.transform.position) <= minDist && GameScene63Manager.ins.isStartScene && !GameScene63Manager.ins.isEndGame)
        {
            progressBar.UpdateBar();
            if (!isMoving)
            {
                StartCoroutine(nameof(StartMoveToNewPos));
            }
        }
    }

    IEnumerator StartMoveToNewPos()
    {
        skeleton.AnimationState.SetAnimation(1, "Angry", true);
        isMoving = true;
        Vector3 start = transform.position;
        Vector3 end;
        float random = Random.Range(0, 3f);
        if (transform.position.x > 0)
        {
            end = new Vector3(-lengthRoad + random, transform.position.y, transform.position.z);
        }
        else
        {
            end = new Vector3(lengthRoad - random, transform.position.y, transform.position.z);
        }

        float eslapsed = 0;
        float seconds = 1.5f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector2.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.25f);
        isMoving = false;
        skeleton.AnimationState.SetAnimation(1, "Idle", true);
    }

    public void EndScene()
    {
        StopAllCoroutines();
    }


}
