using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHead : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
    Vector3 startPos;
    [SerializeField] ParticleSystem particleSystem;
    bool isStartPartical;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (isbeingHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
    private void OnMouseDown()
    {
        isbeingHeld = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!isStartPartical)
        {
            particleSystem.Play();
        }
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        StartCoroutine(StartToMoveBack());
        particleSystem.Stop();
    }

    IEnumerator StartToMoveBack()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;

    }
}
