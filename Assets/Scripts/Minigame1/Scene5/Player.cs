using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 positionStartToRun;
    [SerializeField] float speedAnim;
    [SerializeField] private int cntDirectionMove;
    bool isMoving;
    Vector3 newPosition;
    [SerializeField] float speedMove;
    public bool isBeHitted;
    [SerializeField] List<Vector3> PlayerPositions;
    public bool isStartToRun;
    [SerializeField] SkeletonAnimation playerAnim;

    private void Awake()
    {
        StartCoroutine(MoveToPositionStartToRun());
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (isStartToRun && !GameScene5Manager.ins.isPlayEndScene) Move();
    }

    IEnumerator MoveToPositionStartToRun()
    {
        Vector2 tmpPosition;
        playerAnim.AnimationState.SetAnimation(0, "Run_c", true);
        while (transform.position != positionStartToRun)
        {
            tmpPosition = transform.position;
            transform.position = Vector3.MoveTowards(tmpPosition, positionStartToRun, speedAnim * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        isStartToRun = true;
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        //playerAnim.state.ClearTrack(0);
        //playerAnim.Skeleton.SetToSetupPose();
        playerAnim.AnimationState.SetAnimation(0, "Run_ninja", true);
    }

    float startMouse;
    float endMouse;
    float eslapsed;
    float timeDelay = 0.6f;
    // Delay between 2 move lien tiep
    void Move()
    {
        CheckIsMoving();
        eslapsed += Time.deltaTime;
        if (Input.GetMouseButton(0) && eslapsed >= timeDelay && !isBeHitted)
        {
            endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float directY = (startMouse != 0 ? endMouse - startMouse : 0);
            startMouse = endMouse;
            if ((directY < 0) && !isMoving && cntDirectionMove > -1)
            {
                cntDirectionMove -= 1;
                float newY = PlayerPositions[cntDirectionMove + 1].y;
                newPosition = new Vector3(newPosition.x, newY, 0);
            }

            if ((directY > 0) && !isMoving && cntDirectionMove < 1)
            {
                cntDirectionMove += 1;
                float newY = PlayerPositions[cntDirectionMove + 1].y;
                newPosition = new Vector3(newPosition.x, newY, 0);

            }
            if (isMoving) eslapsed = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            startMouse = endMouse = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speedMove * Time.deltaTime);
    }
    void CheckIsMoving()
    {
        if (Vector2.Distance(transform.position, newPosition) == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObsacleScene15"))
        {

            StartCoroutine(DoAnimationHitted(collision.gameObject));
        }
    }

    IEnumerator DoAnimationHitted(GameObject obsacle)
    {
        playerAnim.AnimationState.SetAnimation(0, "Crying", true);
        playerAnim.AnimationState.SetAnimation(1, "Sit_Idle", true);
        GameScene5Manager.ins.thief.Laugh();
        isBeHitted = true;
        SpawnThings.ins.StopToSpawn();
        yield return new WaitForSeconds(1.5f);
        isBeHitted = false;
        SpawnThings.ins.StartToSpawn();
        Destroy(obsacle);

        playerAnim.state.ClearTrack(0);
        playerAnim.state.ClearTrack(1);
        playerAnim.Skeleton.SetToSetupPose();
        playerAnim.AnimationState.SetAnimation(0, "Run_ninja", true);
        GameScene5Manager.ins.thief.RunAgain();

    }

    IEnumerator MoveToEndPosition()
    {
        float elapsedTime = 0;
        float seconds = 1f;
        Vector3 startingPos = transform.position;
        Vector3 endPos = new Vector3(-1.75f, PlayerPositions[1].y, 0);
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        playerAnim.AnimationState.SetAnimation(0, "Cheer", true);
        transform.position = endPos;

    }

    public void EndScene()
    {
        StartCoroutine(MoveToEndPosition());
    }

}
