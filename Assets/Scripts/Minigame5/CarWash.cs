using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWash : MonoBehaviour
{
    [SerializeField] SpriteRenderer carBody;
    [SerializeField] SpriteRenderer waterSpriteCar;
    [SerializeField] Sprite cleanCar;
    public void ActivewaterSpriteCar()
    {
        waterSpriteCar.gameObject.SetActive(true);
    }

    public void TransformCleanSpriteCar()
    {
        carBody.sprite = cleanCar;
    }

    public void ClearWaterSprite()
    {
        float speed = 0.2f;
        waterSpriteCar.color -= new Color(0, 0, 0, speed * Time.deltaTime);
        if (waterSpriteCar.color.a <= 0)
        {
            Debug.Log("end");
        }
    }
}
