using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rigidTrain;
    Vector3 startPos;
    float eslapsed;
    [SerializeField] float timeBack;
    float sizeTrain;
    float lengthRailway;
    private void Start()
    {
        rigidTrain = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        sizeTrain = GetComponent<Collider2D>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rigidTrain.velocity = new Vector2(0, +speed * Time.deltaTime);
        if (eslapsed > timeBack)
        {
            eslapsed = 0;
            lengthRailway = transform.position.y - startPos.y;
            startPos = new Vector3(transform.position.x, transform.position.y - lengthRailway, transform.position.z);
            transform.position = startPos;
        }
        eslapsed += Time.deltaTime;
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
