using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FingerPrintScanner : MonoBehaviour
{
    [SerializeField] Button buttonScan;
    private void Awake()
    {
        buttonScan.onClick.AddListener(delegate {
            buttonScan.interactable = false;
            buttonScan.GetComponent<ButtonScan_Scene1_3>().BeClicked();
            UIManager_Scene1_3.ins.ActiveScanningGamePlayPanel();
        });
    }
}