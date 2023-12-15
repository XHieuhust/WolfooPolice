using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] float timeMove;
    [SerializeField] float timeDelay;
    private float sizeTrain;
    private void Start()
    {
        Move();
        sizeTrain = GetComponent<BoxCollider2D>().bounds.size.y;
    }
    private void Move()
    {
        StartCoroutine(nameof(StartMove));
    }

    IEnumerator StartMove()
    {
        float eslapsed;
        float seconds = timeMove;

        while (true)
        {
            transform.position = startPos.position;
            eslapsed = 0;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos.position, endPos.position, eslapsed / seconds);
                CheckTrain();
                yield return new WaitForEndOfFrame();
            }
            transform.position = endPos.position;
            yield return new WaitForSeconds(timeDelay);
        }
    }

    public void CheckTrain()
    {
        if (transform.position.y + sizeTrain >= Map.ins.MatrixCells[3, 18].transform.position.y && transform.position.y - sizeTrain <= Map.ins.MatrixCells[3, 18].transform.position.y)
        {
            Map.ins.CanMove[3, 18] = 0;
            if (Map.ins.cellOnCar.indexCol == 18 && Map.ins.cellOnCar.indexRow == 3)
            {
                Map.ins.car.MoveBackRailway();
            }
        }
        else
        {
            Map.ins.CanMove[3, 18] = 1;
        }
    }
}

