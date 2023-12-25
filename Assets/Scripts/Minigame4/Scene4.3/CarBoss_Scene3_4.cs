using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBoss_Scene3_4 : CarEnemy_Scene3_4
{
    [SerializeField] List<Transform> posCar;
    [SerializeField] float timeDelayRandomMove;
    [SerializeField] Radar radar;
    private new void Awake()
    {
        base.Awake();
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 2.5f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToStartPos());
    }

    IEnumerator StartMoveToStartPos()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(3f / 5 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
        RanDomMove();
    }

    private void RanDomMove()
    {
        StartCoroutine(StartRanDomMove());
    }

    IEnumerator StartRanDomMove()
    {
        List<Transform> posCantMove = new List<Transform>();
        List<Transform> posCanMove = new List<Transform>();
        int ranMoveY;
        while (true)
        {
            yield return new WaitForSeconds(timeDelayRandomMove);
            posCantMove = radar.CheckPosCantMove();
            for (int i = 0; i < posCar.Count; ++i)
            {
                int cnt = 0;
                for (int j = 0; j < posCantMove.Count; ++j)
                {
                    if (Mathf.Abs(posCar[i].position.y - posCantMove[j].position.y) >= 0.2f)
                    {
                        cnt++;
                    }
                }
                if (cnt == posCantMove.Count)
                {
                    posCanMove.Add(posCar[i]);
                }
            }
            ranMoveY = Random.Range(0, posCanMove.Count);
            float newY = posCanMove[ranMoveY].position.y;
            StartCoroutine(StartMove(newY));
            for (int i = 0; i < posCanMove.Count; ++i)
            {
                posCanMove.RemoveAt(0);
            }
        }

        IEnumerator StartMove(float newY)
        {
            float eslapsed = 0;
            float seconds = 0.25f;
            float start = transform.position.y;
            float end = newY;
            float posY;


            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                posY = start + (end - start) * eslapsed / seconds;
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);
                yield return new WaitForEndOfFrame();
            }
            transform.position = new Vector3(transform.position.x, end, transform.position.z);

        }

    }
}
