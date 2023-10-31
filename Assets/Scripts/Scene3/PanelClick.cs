using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelClick : MonoBehaviour
{
    [SerializeField] Button trueClickBtn1;
    [SerializeField] Button trueClickBtn2;
    [SerializeField] Button falseClick;
    UnityAction actionBeClicked;
    private void Awake()
    {
        actionBeClicked = TrueClicked;
        trueClickBtn1.onClick.AddListener(actionBeClicked);
        trueClickBtn2.onClick.AddListener(actionBeClicked);

    }

    void TrueClicked()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        GameObject trueTick = Instantiate(UIManager.ins.trueTick, worldPosition, Quaternion.identity);
        StartCoroutine(StartNextTurn(trueTick));
    }

    IEnumerator StartNextTurn(GameObject Tick)
    {
        yield return new WaitForSeconds(0.4f);
        UIManager.ins.cntCompleteTurn += 1;
        UIManager.ins.StartNextTurn();
        Destroy(Tick);
    }
}
