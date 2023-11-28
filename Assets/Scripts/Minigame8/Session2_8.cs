using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Session2_8 : MonoBehaviour
{

    [SerializeField] Bar_Session2_8 bar;
    [SerializeField] Button finger;
    [SerializeField] Button foot;
    [SerializeField] Button shirt;
    [SerializeField] GameObject session_Foot;

    float timeMoveBar = 0.5f;
    private void Awake()
    {
        foot.onClick.AddListener(PlayFootSession);
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
        StartCoroutine(StartFootSession());
    }

    IEnumerator StartFootSession()
    {
        bar.MoveLeft(timeMoveBar);
        yield return new WaitForSeconds(timeMoveBar);
        session_Foot.SetActive(true);
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
}
