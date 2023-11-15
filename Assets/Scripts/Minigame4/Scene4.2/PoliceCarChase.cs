using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarChase : MonoBehaviour
{
    [SerializeField] private int cntDirectionMove;
    bool isMoving;
    Vector3 newPosition;
    [SerializeField] float speedMoveUpDown;
    [SerializeField] List<Transform> CarPositions;
    bool isHitted;
    private void Awake()
    {
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckEndGame();
    }

    float startMouse;
    float endMouse;
    float eslapsed;
    float timeDelay = 0.6f;
    // Delay between 2 move lien tiep
    void Move()
    {
        CheckIsMoving();
        eslapsed += Time.deltaTime;
        if (Input.GetMouseButton(0) && eslapsed >= timeDelay && !isHitted)
        {
            endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float directY = (startMouse != 0 ? endMouse - startMouse : 0);
            startMouse = endMouse;
            if ((directY < 0) && !isMoving && cntDirectionMove > -1)
            {
                cntDirectionMove -= 1;
                float newY = CarPositions[cntDirectionMove + 1].transform.position.y;
                newPosition = new Vector3(newPosition.x, newY, 0);
            }

            if ((directY > 0) && !isMoving && cntDirectionMove < 1)
            {
                cntDirectionMove += 1;
                float newY = CarPositions[cntDirectionMove + 1].transform.position.y;
                newPosition = new Vector3(newPosition.x, newY, 0);

            }
            if (isMoving) eslapsed = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {

            startMouse = endMouse = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speedMoveUpDown * Time.deltaTime);
    }
    void CheckIsMoving()
    {
        if (Vector2.Distance(transform.position, newPosition) <= 0.05f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarChased") && !isHitted)
        {
            isHitted = true;
            PanelDuoiBat.ins.PoliceCarHitCar();
            StartCoroutine(DesTroyCarChased(collision.gameObject));
        }
    }

    // tmp;
    IEnumerator DesTroyCarChased(GameObject ob)
    {
        yield return new WaitForSeconds(1.5F);
        Destroy(ob);
        PanelDuoiBat.ins.BecomeNormal();
        isHitted = false;
    }

    void CheckEndGame()
    {
        if (transform.position.x >= PanelDuoiBat.ins.carViPham.transform.position.x)
        {
            PanelDuoiBat.ins.isEndGame = true;
            MoveToCarViPham();
        }
    }
    void MoveToCarViPham()
    {
        StartCoroutine(StartToMoveCarViPham());
    }

    IEnumerator StartToMoveCarViPham()
    {
        float seconds = 0.75f;
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Vector3 endPos = PanelDuoiBat.ins.carViPham.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos;
    }
}
