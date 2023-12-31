using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Session2_8 : MonoBehaviour
{

    [SerializeField] public Bar_Session2_8 bar;
    [SerializeField] Button finger;
    [SerializeField] Button foot;
    [SerializeField] Button shirt;
    [SerializeField] GameObject session_Foot;
    [SerializeField] Image hintFoot;

    [SerializeField] GameObject session_Finger;
    [SerializeField] GameObject session_Shirt;
    [SerializeField] Wolf_Session_8 wolf;
    [SerializeField] Kat_Session_8 kat;
    bool isOnClick;


    float timeMoveBar = 0.5f;
    int CompleteSessionPlay = 0;
    private void Awake()
    {
        foot.onClick.AddListener(PlayFootSession);
        finger.onClick.AddListener(PlayFingerSession);
        shirt.onClick.AddListener(PlayShirtSession);

    }

    private void OnEnable()
    {
        StartCoroutine(StartPlaySession());
    }

    IEnumerator StartPlaySession()
    {
        bar.MoveRight(timeMoveBar);
        yield return new WaitForSeconds(timeMoveBar);
        SetUpButtons();
    }

    void SetUpButtons()
    {
        finger.transform.parent = transform;
        foot.transform.parent = transform;
        shirt.transform.parent = transform;
        finger.transform.SetAsFirstSibling();
        foot.transform.SetAsFirstSibling();
        shirt.transform.SetAsFirstSibling();
    }

    private void PlayFootSession()
    {
        if (!isOnClick)
        {
            StartCoroutine(StartFootSession());
        }

    }

    IEnumerator StartFootSession()
    {
        isOnClick = true;

        float startScale = foot.transform.localScale.x;
        foot.transform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
        yield return new WaitForSeconds(0.3f);
        foot.transform.localScale = new Vector3(startScale, startScale, startScale);

        bar.MoveLeft(timeMoveBar);
        yield return new WaitForSeconds(timeMoveBar);
        hintFoot.gameObject.SetActive(true);
        hintFoot.transform.position = new Vector3(foot.transform.position.x, foot.transform.position.y, hintFoot.transform.position.z);
        session_Foot.SetActive(true);
    }

    public void EndFootSession()
    {
        session_Foot.SetActive(false);
        Destroy(foot.gameObject);
        UpdateCompleteSessionPlay();

        isOnClick = false;
    }

    private void PlayFingerSession()
    {
        if (!isOnClick)
        {
            StartCoroutine(StartFingerSession());
        }
    }

    IEnumerator StartFingerSession()
    {
        isOnClick = true;

        float startScale = finger.transform.localScale.x;
        finger.transform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
        yield return new WaitForSeconds(0.3f);
        finger.transform.localScale = new Vector3(startScale, startScale, startScale);

        bar.MoveLeft(timeMoveBar);
        yield return new WaitForSeconds(timeMoveBar);
        session_Finger.SetActive(true);
    }

    public void EndFingerSession()
    {
        session_Finger.SetActive(false);
        Destroy(finger.gameObject);
        UpdateCompleteSessionPlay();

        isOnClick = false;

    }


    private void PlayShirtSession()
    {
        if (!isOnClick)
        {
            StartCoroutine(StartShirtSession());
        }
    }

    IEnumerator StartShirtSession()
    {
        isOnClick = true;

        float startScale = shirt.transform.localScale.x;
        shirt.transform.localScale = new Vector3(1.2f * startScale, 1.2f * startScale, 1.2f * startScale);
        yield return new WaitForSeconds(0.3f);
        shirt.transform.localScale = new Vector3(startScale, startScale, startScale);

        bar.MoveLeft(timeMoveBar);
        yield return new WaitForSeconds(timeMoveBar);
        session_Shirt.SetActive(true);
    }

    public void EndShirtSession()
    {
        session_Shirt.SetActive(false);
        Destroy(shirt.gameObject);
        UpdateCompleteSessionPlay();

        isOnClick = false;
    }

    void UpdateCompleteSessionPlay()
    {
        CompleteSessionPlay++;
        if (CompleteSessionPlay == 3)
        {
            EndSession();
        }
    }

    void EndSession()
    {
        StartCoroutine(StartEndSession());
    }

    IEnumerator StartEndSession()
    {
        bar.MoveLeft(0.5f);
        yield return new WaitForSeconds(0.5f);

        wolf.gameObject.SetActive(true);
        kat.gameObject.SetActive(true);
        wolf.MoveRight(1f);
        kat.MoveLeft(1f);
        yield return new WaitForSeconds(3f);
        GameScene84Manager.ins.LoadNewScene();
    }

    

}
