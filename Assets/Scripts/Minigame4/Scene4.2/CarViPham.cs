using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarViPham : MonoBehaviour
{
    [SerializeField] private int cntDirectionMove;
    bool isMoving;
    Vector3 newPosition;
    [SerializeField] List<Transform> CarPositions;
    [SerializeField] float speedStraightNormal;
    [SerializeField] float speedWhenCarHit;
    [SerializeField] float speedMoveUpDown;
    Rigidbody2D rigid;
    float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = speedStraightNormal;
    }

    private void Update()
    {
        if (PanelDuoiBat.ins.isEndGame)
        {
            speed = 0;
        }else if (PanelDuoiBat.ins.isStopGame)
        {
            speed = speedStraightNormal * 4;
        }
        rigid.velocity = new Vector2(-speed * Time.deltaTime, 0);
    }

    // AI ne va cham
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarChased"))
        {
            StopCoroutine(nameof(RandomMove));
            StartCoroutine(nameof(RandomMove));
        }
        if (collision.gameObject.CompareTag("PoliceCarChase"))
        {
            PanelDuoiBat.ins.isEndGame = true;
        }
    }
    float newY;
    IEnumerator RandomMove()
    {
        if (cntDirectionMove == 1)
        {
            cntDirectionMove -= 1;
            newY = CarPositions[cntDirectionMove + 1].transform.position.y;
        }else if (cntDirectionMove == -1)
        {
            cntDirectionMove += 1;
            newY = CarPositions[cntDirectionMove + 1].transform.position.y;
        }else
        {
            int directY = Random.Range(0, 2);
            if (directY == 0)
            {
                newY = CarPositions[cntDirectionMove + 2].transform.position.y;
                cntDirectionMove += 1;
            }
            else
            {
                newY = CarPositions[cntDirectionMove].transform.position.y;
                cntDirectionMove -= 1;
            }
        }

        float eslapsed = 0;
        float seconds = 0.75f;
        while (Mathf.Abs(transform.position.y - newPosition.y) >= 0.1f || eslapsed <= seconds)
        {
            newPosition = new Vector2(transform.position.x, newY);
            transform.position = Vector2.MoveTowards(transform.position, newPosition, speedMoveUpDown * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector2(transform.position.x, newY);
    }
    public void UpDateSpeedWhenCarHit()
    {
        speed = -speedStraightNormal * 10;
    }

    public void BecomeNormal()
    {
        speed = speedStraightNormal;
    }

}
