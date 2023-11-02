using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    private int cntDirectionMove;
    bool isMoving;
    [SerializeField] float distMove;
    [SerializeReference] float timeRandomMove;
    Vector3 newPosition;
    [SerializeField] float speedMove;
    [SerializeField] List<GameObject> ListDoChoi;

    float directY;
    private void Awake()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRandomMove);
            directY = Random.Range(0, 2);
            StartCoroutine(MoveToNewPosition());
        }
    }

    IEnumerator MoveToNewPosition()
    {
        if (directY == 0 && !isMoving && cntDirectionMove > -1)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y - distMove, 0);
            cntDirectionMove -= 1;
        }

        if (directY == 1 && !isMoving && cntDirectionMove < 1)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y + distMove, 0);
            cntDirectionMove += 1;
        }

        Vector2 tmpPosition;
        while(transform.position.y != newPosition.y){
            tmpPosition = transform.position;
            transform.position = Vector2.MoveTowards(tmpPosition, newPosition, speedMove);
            yield return new WaitForEndOfFrame();
        }
    }

}
