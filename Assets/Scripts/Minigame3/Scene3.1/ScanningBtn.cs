using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanningBtn : MonoBehaviour
{
    [SerializeField] Image vanTayCompleted;
    [SerializeField] Image ScanBar;
    [SerializeField] float speed;
    [SerializeField] Transform startVtay;
    [SerializeField] Transform endVtay;
    float lengthScan;
    float endPos;

    private void Start()
    {
        lengthScan = GetComponent<Collider2D>().bounds.extents.y * 2;
        endPos = transform.position.y - lengthScan / 2;
    }
    private void OnMouseDrag()
    {
        if (!GameScene31Manager.ins.isEndGame)
        {
            ScanBar.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

            float newValue = (startVtay.position.y - ScanBar.transform.position.y) / (startVtay.position.y - endVtay.position.y);
            vanTayCompleted.fillAmount = newValue;

            if (ScanBar.transform.position.y <= endPos)
            {
                GameScene31Manager.ins.CompleteScene();
            }
        }

    }

}
