using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBall : MonoBehaviour
{
    SpriteRenderer spriteSoap;
    [SerializeField] Bubble bubble;
    [SerializeField] SoapBallManager soapBallManager;
    bool isClean;
    private void Start()
    {
        spriteSoap = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        CheckDist();
    }

    void CheckDist()
    {
        if(!isClean && Vector2.Distance(transform.position, bubble.transform.position) < 0.5f)
        {
            spriteSoap.enabled = true;
            isClean = true;
            soapBallManager.UpdateEnableSoapBall();
        }
    }
}
