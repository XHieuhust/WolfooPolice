using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPolice_Scene3_4 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] float speed;
    [SerializeField] List<Transform> posCar;
    Rigidbody2D rigid;

    private void Awake()
    {
        transform.position = new Vector3(- Camera.main.orthographicSize * Camera.main.aspect - 3f, transform.position.y, transform.position.z);
        rigid = GetComponent<Rigidbody2D>();
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        StartCoroutine(StartMoveToStartPos());
    }

    IEnumerator StartMoveToStartPos()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(-3f/5 * Camera.main.orthographicSize * Camera.main.aspect, transform.position.y, transform.position.z);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }

        transform.position = end;
        GameScene43Manager.ins.isStartGame = true;
    }

    private void FixedUpdate()
    {
        MoveX();
        MoveY();
    }


    private void MoveX()
    {
        if (GameScene43Manager.ins.isStartGame)
        {
            rigid.velocity = new Vector2(speed * Time.deltaTime, 0);
        }
    }

    float directY;
    float startMouse;
    float endMouse;
    int cntDirectionMove;
    bool isMoving;
    float newY;
    private void MoveY()
    {
        if (GameScene43Manager.ins.isStartGame)
        {
            if (Input.GetMouseButton(0) && !isMoving)
            {
                endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                directY = (startMouse != 0 ? endMouse - startMouse : 0);
                startMouse = endMouse;
                if (directY != 0)
                {
                    if ((directY < 0) && !isMoving && cntDirectionMove > -1)
                    {
                        cntDirectionMove -= 1;
                    }

                    if ((directY > 0) && !isMoving && cntDirectionMove < 1)
                    {
                        cntDirectionMove += 1;
                    }
                    newY = posCar[cntDirectionMove + 1].position.y;
                    StartCoroutine(nameof(StartMove));
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                startMouse = endMouse = 0;
            }
        }
        
    }

    IEnumerator StartMove()
    {
        float eslapsed = 0;
        float seconds = 0.25f;
        float start = transform.position.y;
        float end = newY;
        float posY;

        isMoving = true;
        while (eslapsed <= seconds) 
        {
            eslapsed += Time.deltaTime;
            posY = start + (end - start) * eslapsed/seconds;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(transform.position.x, end, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        isMoving = false;
        startMouse = endMouse = 0;
    }


}
