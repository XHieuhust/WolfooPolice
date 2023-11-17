using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManagerScene52 : MonoBehaviour
{
    [SerializeField] Image iconCar;
    [SerializeField] List<Image> ListStar;
    [SerializeField] Sprite completedStar;
    [SerializeField] Image barFill;
    int completedStartCount;
    Vector3 startPos;
    Vector3 endPos;
    float lengthBar;
    Vector3 normalScale;

    private void Start()
    {
        lengthBar = ListStar[ListStar.Count - 1].transform.position.x - iconCar.transform.position.x;
        normalScale = transform.localScale;
        SetPosStar();
    }

    private void SetPosStar()
    {
        startPos = barFill.transform.position - new Vector3(lengthBar / 2, 0, 0);
        iconCar.transform.position = startPos;
        ListStar[0].transform.position = startPos + new Vector3(lengthBar * 2 / 7, 0, 0);
        ListStar[1].transform.position = startPos + new Vector3(lengthBar * 2 / 3, 0, 0);
        ListStar[2].transform.position = startPos + new Vector3(lengthBar, 0, 0);
      
    }

    public void UpdatePosIcon(float rate)
    {
        StartCoroutine(StartUpdate(rate));
    }

    IEnumerator StartUpdate(float rate)
    {
        float timeUpdate = 0.1f;
        iconCar.transform.position = startPos + new Vector3(rate * lengthBar, 0, 0);
        iconCar.transform.localScale = new Vector3(normalScale.x * 1.2f, normalScale.y * 1.2f, normalScale.z * 1.2f);
        CheckPassOverStar();
        yield return new WaitForSeconds(timeUpdate);
        iconCar.transform.localScale = normalScale;
    }

    private void CheckPassOverStar()
    {
        if((iconCar.transform.position.x >= ListStar[completedStartCount].transform.position.x || Mathf.Abs(iconCar.transform.position.x - ListStar[completedStartCount].transform.position.x) <= 0.05f))
        {
            TransformCompletedStar(ListStar[completedStartCount]);
            completedStartCount++;
            GameScene52Manager.ins.SpeedUp();
        }
    }

    private void TransformCompletedStar(Image star)
    {
        StartCoroutine(StartTransformCompletedStar(star));
    }

    IEnumerator StartTransformCompletedStar(Image star)
    {
        float timeTransform = 0.1f;
        star.transform.localScale = new Vector3(normalScale.x * 1.2f, normalScale.y * 1.2f, normalScale.z * 1.2f);
        star.sprite = completedStar;
        yield return new WaitForSeconds(timeTransform);
        star.transform.localScale = normalScale;
    }
}
