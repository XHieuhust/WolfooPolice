using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBroken : MonoBehaviour
{
    [SerializeField] float timeExist;
    float eslapsed;
    void Update()
    {
        eslapsed += Time.deltaTime;
        if (eslapsed >= timeExist)
        {
            Destroy(gameObject);
        }
    }
}
