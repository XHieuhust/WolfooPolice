using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVirrus : MonoBehaviour
{
    public static InstantiateVirrus ins;

    [SerializeField] List<Sprite> SpritesOfVirrus;

    [SerializeField] List<Transform> PosInstantiateVirrus;

    [SerializeField] Virrus virrus;
    List<Vector3> NewPosInstantiateVirrus = new List<Vector3>();
    int cntDiedVirrus;
    int[] maxDie;

    [SerializeField] int maxDieOfOneVirus;
    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        maxDie = new int[SpritesOfVirrus.Count];
        for (int i = 0; i < SpritesOfVirrus.Count; ++i)
        {
            Virrus newVirrus = Instantiate(virrus, PosInstantiateVirrus[i].position, Quaternion.identity);
            newVirrus.SetSprite(SpritesOfVirrus[i], i);
            maxDie[i] = maxDieOfOneVirus;
        }

        for(int i = SpritesOfVirrus.Count; i < PosInstantiateVirrus.Count; ++i)
        {
            NewPosInstantiateVirrus.Add(PosInstantiateVirrus[i].position);
        }
    }

    public void InstaneAtNewPos(Vector3 oldPos, Sprite oldSprite, int index)
    {
        maxDie[index] -= 1;
        NewPosInstantiateVirrus.Add(oldPos);
        if (maxDie[index] > 0)
        {
            Virrus newVirrus = Instantiate(virrus, NewPosInstantiateVirrus[0], Quaternion.identity);
            newVirrus.SetSprite(oldSprite, index);
            NewPosInstantiateVirrus.RemoveAt(0);
        }
        else
        {
            UpdateDiedVirrus();
        }
    }

    void UpdateDiedVirrus()
    {
        cntDiedVirrus += 1;
        if(cntDiedVirrus == SpritesOfVirrus.Count)
        {
            ToolManager.ins.StartBubble();
            GameScene51Manager.ins.car.ActiveListSoapBalls();
        }
    }
}
