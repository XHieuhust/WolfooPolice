using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Scene1_3 : MonoBehaviour
{
    public static UIManager_Scene1_3 ins;
    [SerializeField] Image table;
    [SerializeField] Image scanningGamePlayPanel;
    private void Awake()
    {
        ins = this;
    }

    public void ActiveFingerScaning()
    {
        table.GetComponent<Table_Scene1_3>().EnableScaning();
    }

    public void ActiveScanningGamePlayPanel()
    {
        scanningGamePlayPanel.gameObject.SetActive(true);
    }

    public void CompleteScanningGamePlayPanel()
    {
        scanningGamePlayPanel.gameObject.SetActive(false);
    }
}
