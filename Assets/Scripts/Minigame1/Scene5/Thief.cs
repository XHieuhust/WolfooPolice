using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Thief : MonoBehaviour
{
    [SerializeField] Vector3 positionStartToRun;
    [SerializeField] float speedAnim;
    private int cntDirectionMove;
    [SerializeReference] float timeRandomMove;
    Vector3 newPosition;
    [SerializeField] float speedMove;
    [SerializeField] List<GameObject> ListDoChoi;
    [SerializeField] List<Vector3> ThiefPositions;
    public bool isStartToRun;
    public float newY;
    [SerializeField] public SkeletonAnimation thiefAnim;

    float directY;
    private void Start()
    {   if(GameScene5Manager.ins)
            GameScene5Manager.ins.thief = GetComponent<Thief>();
        StartCoroutine(MoveToPositionStartToRun());
        newY = transform.position.y;
    }

    IEnumerator MoveToPositionStartToRun()
    {
        thiefAnim.AnimationState.SetAnimation(0, "Run_c", true);
        Vector2 tmpPosition;
        while (transform.position != positionStartToRun)
        {
            tmpPosition = transform.position;
            transform.position = Vector3.MoveTowards(tmpPosition, positionStartToRun, speedAnim * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        SpawnThings.ins.StartToSpawn();
        StartCoroutine(MoveWhenPlayerAnimRun());
    }

    IEnumerator MoveWhenPlayerAnimRun()
    {
        while (!GameScene5Manager.ins.player.isStartToRun)
        {
            transform.position = new Vector2(transform.position.x + speedMove * Time.deltaTime, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(RandomMove());

    }

    IEnumerator RandomMove()
    {
        thiefAnim.AnimationState.SetAnimation(0, "Run_c", true);
        isStartToRun = true;
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        while (!GameScene5Manager.ins.isPlayEndScene)
        {
            yield return new WaitForSeconds(timeRandomMove);
            directY = Random.Range(0, 2);
            StartCoroutine(MoveToNewPosition());
        }
    }

    IEnumerator MoveToNewPosition()
    {
        if ((directY == 0) && cntDirectionMove > -1)
        {
            cntDirectionMove -= 1;
            newY = ThiefPositions[cntDirectionMove + 1].y;
            newPosition = new Vector3(newPosition.x, newY, 0);
        }

        if ((directY == 1) && cntDirectionMove < 1)
        {
            cntDirectionMove += 1;
            newY = ThiefPositions[cntDirectionMove + 1].y;
            newPosition = new Vector3(newPosition.x, newY, 0);

        }

        Vector2 tmpPosition;
        while(transform.position.y != newPosition.y && !GameScene5Manager.ins.isPlayEndScene){
            tmpPosition = transform.position;
            transform.position = Vector2.MoveTowards(tmpPosition, newPosition, speedMove * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Laugh()
    {
        thiefAnim.AnimationState.SetAnimation(0, "Jump", true);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void RunAgain()
    {
        thiefAnim.AnimationState.SetAnimation(0, "Run_c", true);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    IEnumerator MoveToEndPosition()
    {
        float elapsedTime = 0;
        float seconds = 1f;
        Vector3 startingPos = transform.position;
        Vector3 endPos = new Vector3(0, ThiefPositions[1].y, 0);
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        thiefAnim.AnimationState.SetAnimation(0, "Angry", true);
        transform.position = endPos;

    }

    public void EndScene()
    {
        StartCoroutine(MoveToEndPosition());
    }
}
