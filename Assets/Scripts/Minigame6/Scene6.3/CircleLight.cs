using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleLight : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float rate;
    private bool buttonPressed;
    [SerializeField] Image pyramidLight;
    [SerializeField] Image Light;
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    private void FixedUpdate()
    {
        if (buttonPressed)
        {
            // Move follow mouse
            Vector3 newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, rate);

            //Change rotate lights
            Vector3 direct = transform.position - Light.transform.position;
            float angle = Vector2.Angle(direct, Vector2.right);
            pyramidLight.transform.eulerAngles = new Vector3(0, 0, -angle);
            Light.transform.eulerAngles = new Vector3(0, 0, -angle);
        }
    }
}
