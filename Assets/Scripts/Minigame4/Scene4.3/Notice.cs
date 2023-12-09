using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    [SerializeField] float timeExist;
    float eslapsed;
    public void Update()
    {
        eslapsed += Time.deltaTime;
        if(eslapsed  >= timeExist)
        {
            Destroy(gameObject);
        }
    }
}
