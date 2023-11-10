using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toys : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector3 fallPositison;
    [SerializeField] float speedFall;
    Rigidbody2D rigidToy;
    bool isStartMove;
    float maxScale;
    private void Awake()
    {
        rigidToy = GetComponent<Rigidbody2D>();
        // Spawn.y +2f -> Toy.y-2f
        fallPositison = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
        transform.localScale = Vector2.zero;
        maxScale = 0.5f;
        StartCoroutine(StartFallToRoad());
    }

    IEnumerator StartFallToRoad()
    {
        float maxDist = Vector2.Distance(transform.position, fallPositison);
        float curDist;
        while (transform.position != fallPositison)
        {
            transform.position = Vector2.MoveTowards(transform.position, fallPositison, speedFall);
            curDist = Vector2.Distance(transform.position, fallPositison);
            float newScale = (1 - curDist / maxDist) * maxScale;
            transform.localScale = new Vector2(newScale, newScale);
            yield return new WaitForEndOfFrame();
        }
        isStartMove = true;
    }

    private void Update()
    {
        if (isStartMove && !GameScene5Manager.ins.isPlayEndScene)
        {
            if(!GameScene5Manager.ins.player.isBeHitted)
            {   
                rigidToy.velocity = new Vector2(-speedMove, 0);
            }
            else
            {
                rigidToy.velocity = Vector2.zero;
            }

            if(transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TuiSao"))
        {
            GameScene5Manager.ins.tuiSao.GetComponent<TuiSao>().UpdatePositionTuiSao();
            GameScene5Manager.ins.bar.GetComponent<BarProgress>().UpdateBar();

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameScene5Manager.ins.UpdateVpAnDuoc();
            StartMoveToTuiSao();
        }
    }

    IEnumerator MoveToTuiSao()
    {
        Vector3 tuiSao = GameScene5Manager.ins.tuiSao.transform.position;
        float speedFly = 50;
        float maxDist = Vector2.Distance(transform.position, tuiSao);
        float curDist;
        float newScale;
        while (gameObject)
        {
            while (transform.position != tuiSao)
            {
                transform.position = Vector3.MoveTowards(transform.position, tuiSao, speedFly * Time.deltaTime);
                curDist = Vector2.Distance(transform.position, tuiSao);
                newScale = curDist / maxDist * maxScale;
                transform.localScale = new Vector2(newScale, newScale);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void StartMoveToTuiSao()
    {
        StartCoroutine(MoveToTuiSao());
    }
}
