using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rigidCano;
    Vector3 startPos;
    float eslapsed;
    [SerializeField] float timeBack;
    float lengthRiver;
    private void Start()
    {
        rigidCano = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        rigidCano.velocity = new Vector2(0, -speed * Time.deltaTime);
        if (eslapsed > timeBack)
        {
            eslapsed = 0;
            lengthRiver = transform.position.y - startPos.y;
            startPos = new Vector3(transform.position.x, transform.position.y - lengthRiver, transform.position.z);
            transform.position = startPos;
        }
        eslapsed += Time.deltaTime;
    }
}
