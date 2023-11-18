using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMinigame6 : MonoBehaviour
{
    [SerializeField] WolfooMinigame6 wolfoo;

    float lengthCam;
    private void Start()
    {
        lengthCam = Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void Update()
    {
        if (!wolfoo.isFallingDown)
        {
            transform.position = new Vector3(wolfoo.transform.position.x + lengthCam * 2 / 3, transform.position.y, transform.position.z);
        }
    }
}
