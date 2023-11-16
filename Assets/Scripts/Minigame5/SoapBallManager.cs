using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBallManager : MonoBehaviour
{
    [SerializeField] List<SoapBall> SoapBalls;
    int cntCleanedSoapBalls;

    public void UpdateCntCleanedSoapBall()
    {
        cntCleanedSoapBalls++;
        if (cntCleanedSoapBalls == SoapBalls.Count)
        {
            Debug.Log("end");
        }
    }
}
