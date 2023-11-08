using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class IntroPanel : MonoBehaviour
{
    [SerializeField] public Button btnBoDam;
    [SerializeField] SkeletonGraphic wolfooNam;
    [SerializeField] SkeletonGraphic wolfooNu;
    [SerializeField] Image screen;
    [SerializeField] Image bg;

    void Start()
    {
        btnBoDam.GetComponent<Button>().onClick.AddListener(delegate
        {
            wolfooNam.AnimationState.SetAnimation(0, "Cheer", false);
            wolfooNu.AnimationState.SetAnimation(0, "Cheer", false).Complete += IntroPanel_Complete; ;
        });
    }

    private void IntroPanel_Complete(Spine.TrackEntry trackEntry)
    {
        StartCoroutine(MoveDownCamera(this.gameObject));
        StartCoroutine(MoveDownCamera(wolfooNam.gameObject));
        StartCoroutine(MoveDownCamera(wolfooNu.gameObject));
        StartCoroutine(MoveCenterCamera(screen.gameObject));
        StartCoroutine(EnlargeScreen(screen.gameObject));
    }

    IEnumerator MoveDownCamera(GameObject ob)
    {
        float elapsedTime = 0;
        float seconds = 1;
        Vector3 startingPos = ob.GetComponent<RectTransform>().position;
        Vector3 newPos = startingPos - new Vector3(0, 10, 0);
        while (elapsedTime < seconds)
        {
            ob.GetComponent<RectTransform>().position = Vector3.Lerp(startingPos, newPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        ob.GetComponent<RectTransform>().position = newPos;
    }

    IEnumerator MoveCenterCamera(GameObject ob)
    {

        RectTransform rect = ob.GetComponent<RectTransform>();
        float elapsedTime = 0;
        float seconds = 1;
        Vector3 startingPos = rect.position;
        Vector3 newPos = Vector3.zero;
        while (elapsedTime < seconds)
        {
            rect.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        rect.position = newPos;

    }

    IEnumerator EnlargeScreen(GameObject ob)
    {
        float seconds = 1;
        int cnt = 100;
        RectTransform rect = ob.GetComponent<RectTransform>();
        Vector3 startScale = rect.localScale;
        Vector3 newScale = new Vector3(startScale.x * 1.5f, startScale.y * 1.5f, startScale.z * 1.5f);
        float dx = (newScale.x - startScale.x) / (cnt);
        while (rect.localScale.x <= newScale.x)
        {
            rect.localScale += new Vector3(dx, dx, dx);
            yield return new WaitForSeconds(seconds / cnt);
        }
        rect.localScale = newScale;
        ob.GetComponent<Screen>().SetActiveImageMap();
    }

}
