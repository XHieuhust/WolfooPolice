using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class GameScene31Manager : MonoBehaviour
{
    public static GameScene31Manager ins;
    [SerializeField] GameObject dia;
    [SerializeField] WolfooAstray wolfoo;
    [SerializeField] GameObject MayQuetVanTay;
    public int point = 0;
    int maxPoint = 3;
    private void Start()
    {
        ins = this;
    }

    public void UpdatePoint()
    {
        point++;
        wolfoo.Laugh();
        if(point == maxPoint)
        {
            Destroy(dia);
            ActiveMayQuetVanTay();
        }
    }

    void ActiveMayQuetVanTay()
    {
        
        StartCoroutine(StartActiveMayQuetVanTay());
    }

    IEnumerator StartActiveMayQuetVanTay()
    {
        yield return new WaitForSeconds(2f);
        wolfoo.StartQuetVanTay();
        MayQuetVanTay.SetActive(true);
    }
}
