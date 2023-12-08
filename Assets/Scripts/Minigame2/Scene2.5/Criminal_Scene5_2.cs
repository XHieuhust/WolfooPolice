using Spine.Unity;
using System.Collections;
using UnityEngine;

public class Criminal_Scene5_2 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    Vector3 startPos;
    Vector3 endPos;
    private float eslapsed = 0;
    [SerializeField] float timeMove;
    [SerializeField] float startScale;
    [SerializeField] float endScale;
    [SerializeField] Transform end;
    [SerializeField] float rateAttack;
    [SerializeField] bool isAttacking;
    [SerializeField] float timeBeAttacked;
    [SerializeField] float timeDecreaseWhenBeAttacked;
    public delegate void CriminalAttack();
    public static event CriminalAttack criminalAttack;

    private bool isGetMad;
    private int cnttBullet;


    private void Awake()
    {
        startPos = transform.position;
        endPos = end.position;
        transform.localScale = new Vector3(startScale, startScale, startScale);

        // Start Game
        StartCoroutine(StartNewTurn(0.5f));

    }

    private void OnEnable()
    {
        GameScene25Manager.startTurn += NewTurn;
    }

    IEnumerator StartScaleUp()
    {
        float seconds = timeMove;
        Vector3 start = transform.position;
        Vector3 end = endPos;
        skeleton.AnimationState.SetAnimation(0, "Walk_Angry", true);
        float rate = eslapsed/seconds;
        do
        {
            transform.position = Vector3.Lerp(start, end, rate);
            SetScale(rate);
            eslapsed += Time.deltaTime;
            rate = eslapsed / seconds;
            // sap tan cong
            if (rate >= rateAttack && !isAttacking)
            {
                isAttacking = true;
                criminalAttack?.Invoke();
            }
            yield return new WaitForEndOfFrame();
        } while (eslapsed <= seconds);
        transform.position = end;
        SetScale(1);
        SetAnimAttack();
        //
    }

    private void SetScale(float rate)
    {
        transform.localScale = new Vector3(startScale + (endScale - startScale) * rate, startScale + (endScale - startScale) * rate, startScale + (endScale - startScale) * rate);
    }

    private void SetAnimAttack()
    {
        isAttacking = false;
        skeleton.AnimationState.SetAnimation(0, "Attack", false).Complete += Criminal_Scene5_2_Complete;
    }

    private void NewTurn(float timeStartTurn)
    {
        StartCoroutine(nameof(StartNewTurn), timeStartTurn);
    }
    IEnumerator StartNewTurn(float timeStartTurn)
    {
        eslapsed = 0;
        transform.position = startPos;
        SetScale(0);
        yield return new WaitForSeconds(timeStartTurn);
        isGetMad = false;
        StartCoroutine(nameof(StartScaleUp));
    }

    private void Criminal_Scene5_2_Complete(Spine.TrackEntry trackEntry)
    {
        GameScene25Manager.ins.StartNewTurn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when bullet broken
        if (collision.gameObject.CompareTag("Bullet") && !isGetMad)
        {
            BeAttacked();
        }
    }

    private void BeAttacked()
    {
        StopCoroutine(nameof(StartScaleUp));
        StopCoroutine(nameof(StartBeAttacked));
        StartCoroutine(nameof(StartBeAttacked));
    }

    IEnumerator StartBeAttacked()
    {
        skeleton.AnimationState.SetAnimation(0, "Hit", false);
        StopCoroutine(nameof(StartScaleUp));
        cnttBullet++;
        GameScene25Manager.ins.UpdatePoint();
        eslapsed -= timeDecreaseWhenBeAttacked;
        if (eslapsed <= 0)
        {
            eslapsed = 0;
        }
        transform.position = Vector3.Lerp(startPos, endPos, eslapsed / timeMove);
        SetScale(eslapsed / timeMove);

        yield return new WaitForSeconds(timeBeAttacked);
        StartCoroutine(nameof(StartScaleUp));
    }

    public void GetMad()
    {
        StopCoroutine(nameof(StartBeAttacked));
        isGetMad = true;
        StartCoroutine(nameof(StartScaleUp));
    }
}
