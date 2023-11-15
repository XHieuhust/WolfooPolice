using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChased : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PanelDuoiBat.ins.isEndGame)
        {
            speed = 0;
        }
        rigid.velocity = new Vector2(-speed * Time.deltaTime, 0);
        CheckToDestroy();
    }
    void CheckToDestroy()
    {
        if (transform.position.x <= Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 10f)
        {
            Destroy(gameObject);
        }
    }

}
