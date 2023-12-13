using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FingerPrintScanner : MonoBehaviour
{
    [SerializeField] Button buttonScan;
    [SerializeField] Image rayCompleteScan;

    private void Awake()
    {
        buttonScan.onClick.AddListener(delegate {
            buttonScan.interactable = false;
            buttonScan.GetComponent<ButtonScan_Scene1_3>().BeClicked();
        });
    }

    private void OnEnable()
    {
        UIManager_Scene1_3.completeScanning += CompleteScanning;
    }

    private void OnDestroy()
    {
        UIManager_Scene1_3.completeScanning -= CompleteScanning;
    }

    public void CompleteScanning()
    {
        rayCompleteScan.gameObject.SetActive(true);
    }
}
