using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager_Scene2_2 : MonoBehaviour
{
    [SerializeField] Rope_Scene2_2 leftRope;
    [SerializeField] Rope_Scene2_2 rightRope;
    int cntEquipRope;
    public float timeDelayMove;
    public void StartTurn(float seconds)
    {
        StartCoroutine(StartMoveRope(seconds));
    }
    IEnumerator StartMoveRope(float seconds)
    {
        leftRope.MoveDown(seconds);
        yield return new WaitForSeconds(timeDelayMove);
        rightRope.MoveDown(seconds);
    }

    public void UpdateEquippedRope()
    {
        cntEquipRope++;
        if (cntEquipRope == 2)
        {
            GameScene22Manager.ins.UpdateTurn();
        }
    }
}
