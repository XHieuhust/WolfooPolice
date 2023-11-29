using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session1_8 : MonoBehaviour
{
    [SerializeField] Wolf_Session_8 wolfoo;
    [SerializeField] Kat_Session_8 kat;

    [SerializeField] float timeMove;

    private void Start()
    {
        PlaySession();
    }

    void PlaySession()
    {
        StartCoroutine(StartSession());
    }

    IEnumerator StartSession()
    {
        wolfoo.MoveUp(timeMove);
        kat.MoveUp(timeMove);

        yield return new WaitForSeconds(timeMove + 1.5f);

        wolfoo.MoveDown(timeMove);
        kat.MoveDown(timeMove);

        yield return new WaitForSeconds(timeMove);
        SessionManager_8.ins.EnableNextSession();
    }
}
