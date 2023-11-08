using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speedShot;
    [SerializeField] GameObject bulletBroken;
    List<GameObject> ListBulletGoThrough = new List<GameObject>();
    public bool isOfPolice;
    public void ShotToGoal(Vector3 goalPosition)
    {
        StartCoroutine(StartMoveToGoalPosition(goalPosition));
    }

    IEnumerator StartMoveToGoalPosition(Vector3 goalPosition)
    {
        while (Mathf.Sqrt((transform.position.x - goalPosition.x) * (transform.position.x - goalPosition.x) +
            (transform.position.y - goalPosition.y) * (transform.position.y - goalPosition.y)) >= 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, goalPosition, speedShot * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Instantiate(bulletBroken, transform.position, Quaternion.identity);
        CheckToDestroyCuop();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cuop"))
        {
            ListBulletGoThrough.Add(collision.gameObject);
        }
    }

    void CheckToDestroyCuop()
    {
        int index = 0;
        float minDist = 100000;
        if (ListBulletGoThrough.Count == 0) return;
        for(int i = 0; i < ListBulletGoThrough.Count; ++i)
        {
            float dis = Mathf.Sqrt((transform.position.x - ListBulletGoThrough[i].transform.position.x) * (transform.position.x - ListBulletGoThrough[i].transform.position.x) +
            (transform.position.y - ListBulletGoThrough[i].transform.position.y) * (transform.position.y - ListBulletGoThrough[i].transform.position.y));
            if(dis < minDist)
            {
                minDist = dis;
                index = i;
            }
        }
        if(isOfPolice)
            Destroy(ListBulletGoThrough[index]);
    }
}
