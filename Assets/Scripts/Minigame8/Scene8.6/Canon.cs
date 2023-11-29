using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject body;
    [SerializeField] GameObject light;

    bool isTaking;
    private void OnMouseDown()
    {
        if (!isTaking)
        {
            TakePhoto();
        }
    }

    void TakePhoto()
    {
        StartCoroutine(StartTakePhoto());
    }

    IEnumerator StartTakePhoto()
    {
        isTaking = true;
        float eslapsed = 0;
        float seconds = 0.5f;

        Vector3 start, end;
        start = button.transform.position;
        end = start - new Vector3(0, 0.5f, 0);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            button.transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            yield return new WaitForEndOfFrame();                 
        }
        button.transform.position = end;



        eslapsed = 0;
        start = button.transform.position;
        end = start + new Vector3(0, 0.5f, 0);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            button.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        button.transform.position = end;
    }
}
