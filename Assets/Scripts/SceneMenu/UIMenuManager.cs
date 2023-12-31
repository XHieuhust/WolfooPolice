using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMenuManager : MonoBehaviour
{
    [SerializeField] List<int> numbersStartScene;
    [SerializeField] List<Button> ListButtons;
    [SerializeField] List<Image> ListImagesGamePlay;
    private int indexImagesGame;
    CanvasGroup canvasGroup;

    public delegate void EButtonClicked();
    public static event EButtonClicked buttonCliked;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        SetFuncButton();
    }


    private void OnEnable()
    {
        Police_SceneIntro.completeIntro += CanClick;
    }

    private void OnDestroy()
    {
        Police_SceneIntro.completeIntro -= CanClick;
    }


    public void SetFuncButton()
    {
        for (int i = 0; i < ListButtons.Count; ++i)
        {
            int index = i;
            ListButtons[index].onClick.AddListener(delegate
            {
                buttonCliked?.Invoke();
                PlayerPrefs.SetString("curMinigame", "Scene" + (index + 1).ToString());
                PlayerPrefs.SetInt("curScene", numbersStartScene[index]);
                ListButtons[index].GetComponent<ButtonMinigame>().BeClicked();
                indexImagesGame = index;
                StartCoroutine(nameof(StartPlay));
            });
        }
    }

    IEnumerator StartPlay()
    {
        IsClicked();
        yield return new WaitForSeconds(0.5f);
        foreach(Button button in ListButtons)
        {
            button.GetComponent<ButtonMinigame>().ScaleDown();
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartScaleUpImagePlay(ListImagesGamePlay[indexImagesGame].gameObject));
        yield return new WaitForSeconds(2f);
        SceneMenuManager.ins.PlayMinigame();
    }


    IEnumerator StartScaleUpImagePlay(GameObject ob)
    {
        float eslapsed = 0;
        float seconds = 0.25f;
        float end = ob.transform.localScale.x;
        float start = 0;
        ob.transform.localScale = new Vector3(ob.transform.localScale.x, start, ob.transform.localScale.z);
        ob.SetActive(true);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            ob.transform.localScale = new Vector3(ob.transform.localScale.x, start + (end - start) * eslapsed / seconds, ob.transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        ob.transform.localScale = new Vector3(ob.transform.localScale.x, end, ob.transform.localScale.z);
    }

    private void CanClick()
    {
        canvasGroup.blocksRaycasts = true;
    }

    private void IsClicked()
    {
        canvasGroup.blocksRaycasts = false;
    }
}
