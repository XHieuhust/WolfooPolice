using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHead : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
    Vector3 startPos;
    [SerializeField] ParticleSystem particleSystem;
    bool isStartPartical;
    [SerializeField] Transform PosRaycastLeft;
    [SerializeField] Transform PosRaycastRight;
    RaycastHit2D[] hitLeft;
    RaycastHit2D[] hitRight;
    public LayerMask layer;
    float distRaycast;
    [SerializeField] float speedRay;
    List<GameObject> Hits;
    [SerializeField] SoapBallManager soapBallManager;
    private void Awake()
    {
        Hits = new List<GameObject>();
        startPos = transform.position;
    }

    private void OnEnable()
    {
        StartCoroutine(MoveToStartPos());
    }

    IEnumerator MoveToStartPos()
    {
        Vector3 startPos = transform.position + new Vector3(0, 5f, 0);
        Vector3 endPos = transform.position;
        float eslapsed = 0;
        float seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPos;
    }

    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            if (distRaycast <= 10f)
            {
                distRaycast += speedRay * Time.deltaTime;
            }
            hitLeft = Physics2D.RaycastAll(PosRaycastLeft.position, Vector2.down, distRaycast, layer);
            hitRight = Physics2D.RaycastAll(PosRaycastRight.position, Vector2.down, distRaycast, layer);
            if (hitLeft != null || hitRight != null)
            {

                // Get coliders raycast hit
                foreach (RaycastHit2D soapBall in hitLeft)
                {
                    if(!Hits.Contains(soapBall.collider.gameObject))
                    {
                        Hits.Add(soapBall.collider.gameObject);
                    }
                }
                foreach (RaycastHit2D soapBall in hitRight)
                {
                    if (!Hits.Contains(soapBall.collider.gameObject))
                    {
                        Hits.Add(soapBall.collider.gameObject);
                    }
                }
                UpdateTimeWash();
                Hits.Clear();
            }

        }
    }

    void UpdateTimeWash()
    {
        foreach (GameObject soapBall in Hits)
        {
            soapBallManager.CleanSoapBall(soapBall);
        }
    }

    private void OnMouseDown()
    {
        isbeingHeld = true;
        distRaycast = 0;    
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!isStartPartical)
        {
            particleSystem.Play();
        }

    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        StartCoroutine(StartToMoveBack());
        particleSystem.Stop();
    }

    IEnumerator StartToMoveBack()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;

    }   

    
}
