using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayBanTocDo : MonoBehaviour
{
    LineRenderer lineRender;
    [SerializeField] Transform startLine;
    [SerializeField] float timeExist;
    void Start()
    {
        Vector3 start = new Vector3(startLine.position.x, startLine.position.y, 0);
        lineRender = GetComponent<LineRenderer>();
        lineRender.SetPosition(0, start);
        lineRender.SetPosition(1, start);
    }

    public void UpdateEndLine(Transform enemyCar)
    {
        StopFollowEnemyCar();
        StartCoroutine(nameof(StartToFollowEnemyCar), enemyCar);
    }

    IEnumerator StartToFollowEnemyCar(Transform enemyCar)
    {

        float eslasped = 0;
        while(eslasped <= timeExist && enemyCar)
        {
            eslasped += Time.deltaTime;
            Vector3 endLine = new Vector3(enemyCar.transform.position.x, enemyCar.transform.position.y, 0);
            lineRender.SetPosition(1, endLine);
            yield return new WaitForEndOfFrame();
        }
        lineRender.SetPosition(1, startLine.position);
    }

    public void StopFollowEnemyCar()
    {
        StopCoroutine(nameof(StartToFollowEnemyCar));
        lineRender.SetPosition(1, startLine.position);
    }

}
