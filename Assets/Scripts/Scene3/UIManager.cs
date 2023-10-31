using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    [SerializeField] PanelClick Turn1;
    [SerializeField] PanelClick Turn2;
    [SerializeField] PanelClick Turn3;

    [SerializeField] public GameObject falseTick;
    [SerializeField] public GameObject trueTick;
    public int cntCompleteTurn;

    private void Start()
    {
        ins = this;
    }

    public void StartNextTurn()
    {
        if (cntCompleteTurn == 1) StartTurn2();
        if (cntCompleteTurn == 2) StartTurn3();
        if (cntCompleteTurn == 3) Debug.Log("End");
    }
    void StartTurn2()
    {
        Turn1.gameObject.SetActive(false);
        Turn2.gameObject.SetActive(true);
    }

    void StartTurn3()
    {
        Turn2.gameObject.SetActive(false);
        Turn3.gameObject.SetActive(true);
    }


}
