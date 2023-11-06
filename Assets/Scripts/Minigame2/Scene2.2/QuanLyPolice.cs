using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyPolice : MonoBehaviour
{
    public static QuanLyPolice ins;
    public List<GameObject> ListPoliceDaMacDo = new List<GameObject>(2);
    [SerializeField] QuanLyTrangPhuc day1;
    [SerializeField] QuanLyTrangPhuc day2;

    private void Start()
    {
        ins = this;
    }

    public bool CheckPoliceDaMacDo(GameObject ob)
    {
       foreach (GameObject tmp in ListPoliceDaMacDo)
        {
            if (tmp == ob) return true;
        }
        return false;
    }

    public void AddPoliceDaMacDo(GameObject ob)
    {
        ListPoliceDaMacDo.Add(ob);
        if(ListPoliceDaMacDo.Count == 2)
        {
            ListPoliceDaMacDo.Clear();
            GameScene22Manager.ins.UpdateTurn();
        }
    }
}
