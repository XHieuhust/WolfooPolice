using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virrus : MonoBehaviour
{
    SpriteRenderer spriteVirrus;

    int indexSprite;
    private void Awake()
    {
        spriteVirrus = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite newSprite, int index)
    {
        spriteVirrus.sprite = newSprite;
        indexSprite = index;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            InstantiateVirrus.ins.InstaneAtNewPos(transform.position, spriteVirrus.sprite, indexSprite);
            Destroy(gameObject);
        }
    }


}
