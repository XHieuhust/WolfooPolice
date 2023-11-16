using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
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
        //if (transform.parent)
        //{
        //    offset -= transform.parent.position;
        //}
    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
    }
}
