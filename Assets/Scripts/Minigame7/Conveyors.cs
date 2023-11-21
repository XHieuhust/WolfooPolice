using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyors : MonoBehaviour
{
    [SerializeField] List<Rigidbody2D> ListConveyor;

    [SerializeField] float speed;

    float length;
    float minPos;
    private void Start()
    {
        length = ListConveyor[0].GetComponent<SpriteRenderer>().size.x;
        minPos = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        for (int i = 0; i < ListConveyor.Count; ++i)
        {
            ListConveyor[i].velocity = Vector2.left * speed;
        }
    }
    private void Update()
    {
        for(int i = 0; i < ListConveyor.Count; ++i)
        {
            if (ListConveyor[i].transform.position.x + length/2 < minPos)
            {
                ListConveyor[i].transform.position = ListConveyor[(i - 1 + ListConveyor.Count) % ListConveyor.Count].transform.position + new Vector3(length - 0.05f, 0, 0);
            }
        }
    }
} 
