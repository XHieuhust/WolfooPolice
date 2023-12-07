using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager_Scene2_2 : MonoBehaviour
{
    [SerializeField] Rope_Scene2_2 leftRope;
    [SerializeField] Rope_Scene2_2 rightRope;
    int cntEquipRope;
    public float timeDelayBetween2Rope;
    public void StartTurn()
    {
        StartCoroutine(StartMoveRope());
    }
    IEnumerator StartMoveRope()
    {
        leftRope.StartTurn();
        yield return new WaitForSeconds(timeDelayBetween2Rope);
        rightRope.StartTurn();
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
