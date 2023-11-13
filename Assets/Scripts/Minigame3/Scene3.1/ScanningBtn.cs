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

    bool isEndGame;
    private void Start()
    {
        lengthScan = GetComponent<Collider2D>().bounds.extents.y * 2;
        endPos = transform.position.y - lengthScan / 2;
    }
    private void OnMouseDrag()
    {
        ScanBar.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        
        vanTayCompleted.fillAmount = (startVtay.position.y - ScanBar.transform.position.y) / (startVtay.position.y - endVtay.position.y);

        if(ScanBar.transform.position.y <= endPos && !isEndGame)
        {
            isEndGame = true;
            Debug.Log("End Game");
        }
    }

}
