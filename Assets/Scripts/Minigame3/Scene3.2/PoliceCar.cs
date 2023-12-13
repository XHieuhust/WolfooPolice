using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PoliceCar : MonoBehaviour
{
    bool isMoving;
    [SerializeField] float timeMove;
    IEnumerator co;
    Image imgCar;
    public bool isCanMove;
    private void Start()
    {
        isCanMove = true;
        imgCar = GetComponent<Image>();
    }
    public void Move(int newRow, int newCol, Vector3 newPos)
    {
        if (isCanMove)
        {
            co = MoveToNewPosition(newRow, newCol, newPos);
            StartCoroutine(co);
        }

    }
    
    IEnumerator MoveToNewPosition(int newRow, int newCol, Vector3 newPos)
    {
        bool canMove = Map.ins.CanMove[newRow, newCol] == 1 ? true : false;
        int oldRow = Map.ins.cellOnCar.indexRow;
        int oldCol = Map.ins.cellOnCar.indexCol;
        if (Mathf.Abs(newRow - oldRow) + Mathf.Abs(newCol - oldCol) == 1 && canMove && !isMoving)
        {
            Map.ins.UpdatePositionCar(newRow, newCol);
            int newRotation = (newCol - oldCol) * 90 + (newRow - oldRow == -1 ? 180 : 0);
            transform.eulerAngles = new Vector3(0, 0, newRotation);
            isMoving = true;
            float elapsedTime = 0;
            Vector3 startingPos = transform.position;
            while (elapsedTime < timeMove)
            {
                transform.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / timeMove));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.position = newPos;
            isMoving = false;
            Map.ins.cam.UpdateCameraPos(newCol);
        }

    }

    public void MoveBackBridge()
    {
        StopCoroutine(co);
        StartCoroutine(Flicker());
        transform.position = Map.ins.MatrixCells[2, 4].transform.position;
        Map.ins.cellOnCar = Map.ins.MatrixCells[2, 4];
        isMoving = false;
    }

    public void MoveBackRailway()
    {
        StopCoroutine(co);
        StartCoroutine(Flicker());
        transform.position = Map.ins.MatrixCells[3, 17].transform.position;
        Map.ins.cellOnCar = Map.ins.MatrixCells[3, 17];
        isMoving = false;
    }

    IEnumerator Flicker()
    {
        isCanMove = false;
        float eslapsed = 0;
        float timeFlick = 2f;
        float speedFlick = 1f;
        while (eslapsed < timeFlick)
        {
            imgCar.color -= new Color(0, 0, 0, speedFlick * Time.deltaTime);
            if(imgCar.color.a <= 0)
            {
                imgCar.color = new Color(imgCar.color.r, imgCar.color.g, imgCar.color.b, 1);
            }
            eslapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        imgCar.color = new Color(imgCar.color.r, imgCar.color.g, imgCar.color.b, 1);
        isCanMove = true;
    }


}
