using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBallManager : MonoBehaviour
{
    int enableSoapBalls;
    int clearSoapBalls;
    [SerializeField] List<GameObject> SoapBalls;
    [SerializeField] float timeWashMax;
    List<float> timeWash;
    public delegate void EEndShower();
    public static event EEndShower eEndShower;
    private void Start()
    {
        timeWash = new List<float>(SoapBalls.Count);
        for(int i = 0; i < SoapBalls.Count; i++)
        {
            timeWash.Add(0);
        }
    }
    public void UpdateEnableSoapBall()
    {
        enableSoapBalls++;
        if (enableSoapBalls == SoapBalls.Count)
        {
            GameScene51Manager.ins.car.TransformCleanSpriteCar();
            ToolManager.ins.StartShower();
        }
    }

    public void CleanSoapBall(GameObject soapBall)
    {
        int index = SoapBalls.IndexOf(soapBall);
        timeWash[index] += Time.deltaTime;
        if (timeWash[index] >= timeWashMax)
        {
            Destroy(soapBall);
            UpdateClearSoapBall();
        }
    }

    private void UpdateClearSoapBall()
    {
        clearSoapBalls++;
        if (clearSoapBalls == SoapBalls.Count / 2)
        {
            GameScene51Manager.ins.car.ActivewaterSpriteCar();
        }
        if (clearSoapBalls == SoapBalls.Count)
        {
            eEndShower?.Invoke();
            ToolManager.ins.StartTowel();
        }
    }
}
