using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadChaseEnemy : MonoBehaviour
{
    [SerializeField] Transform BackPos;
    Rigidbody2D rigidRoad;
    [SerializeField] float speedNormal;
    float speed;
    float sizeRoad;
    private void Start()
    {
        speed = speedNormal;
        rigidRoad = GetComponent<Rigidbody2D>();
        sizeRoad = Mathf.Abs(transform.position.x - BackPos.position.x);
        
    }

    private void Update()
    {
        if (PanelDuoiBat.ins.isEndGame)
        {
            speed = 0;
        }
        rigidRoad.velocity = new Vector2(-speed * Time.deltaTime, 0);
        CheckToBackStartPos();

    }

    void CheckToBackStartPos()
    {
        if(transform.position.x + sizeRoad / 2 <= Camera.main.transform.position.x - Camera.main.orthographicSize*Camera.main.aspect)
        {
            transform.position = BackPos.position + new Vector3(sizeRoad, 0, 0);
        }
    }

    public void DecreaseSpeed()
    {
        speed = 0.4f * speedNormal;
    }

    public void InceaseToNormal()
    {
        speed = speedNormal;
    }
}
