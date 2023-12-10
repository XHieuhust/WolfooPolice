using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] float speedAllow;
    [SerializeField] float speedIllegal;
    [SerializeField] GameObject wheelCar1;
    [SerializeField] GameObject wheelCar2;
    [SerializeField] float speedRotateWheelNormal;
    [SerializeField] Image smoke;
    public bool isIllegal;
    Rigidbody2D rigidEnemyCar;
    private void Start()
    {
        rigidEnemyCar = GetComponent<Rigidbody2D>();
        int ranDom = Random.Range(0, 2);
        if(ranDom == 0)
        {
            isIllegal = true;
            smoke.gameObject.SetActive(true);
        }
    }

    private void RotateWheelCar()
    {
        float speedRotate;
        if (!isIllegal)
        {
            speedRotate = speedRotateWheelNormal;
        }
        else
        {
            speedRotate = speedRotateWheelNormal * speedIllegal / speedAllow;
        }
        wheelCar1.transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
        wheelCar2.transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (!isIllegal)
        {
            rigidEnemyCar.velocity = new Vector2(speedAllow * Time.deltaTime, 0);
            
        }
        else
        {
            rigidEnemyCar.velocity = new Vector2(speedIllegal * Time.deltaTime, 0);
        }
        RotateWheelCar();
        CheckDestroy();
    }

    private void CheckDestroy()
    {
        if(transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        GameScene42Manager.ins.UpdatePoint(isIllegal, transform.GetChild(0));
        if (isIllegal)
        {
            isIllegal = false;
            smoke.gameObject.SetActive(false);
        }
    }
}
