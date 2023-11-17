using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOnRoad : MonoBehaviour
{
    [SerializeField] Camera cam;

    private void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z);
    }
}
