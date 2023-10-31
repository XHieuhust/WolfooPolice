using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour
{
    [SerializeField] public ButtonBoDam btnBoDam;
    void Start()
    {
        btnBoDam.GetComponent<Button>().onClick.AddListener(delegate
        {
            ScenesManager.ins.LoadScene2();
        });
    }
}
