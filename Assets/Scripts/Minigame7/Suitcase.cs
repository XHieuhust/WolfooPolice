using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitcase : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteSuitcase;
    BoxCollider2D collider;
    bool isillegal;
    bool isOnClick;
    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public void SetUp(Sprite sprite, bool illegal)
    {
        spriteSuitcase.sprite = sprite;
        float sizeX = spriteSuitcase.sprite.bounds.size.x;
        float sizey = spriteSuitcase.sprite.bounds.size.y;
        collider.size = new Vector2(sizeX, sizey);
        collider.offset = new Vector2(0, sizey / 2);

        isillegal = illegal;
    }

    private void OnMouseDown()
    {
        if (!isOnClick)
        {
            if (isillegal)
            {

            }
            else
            {
                StartCoroutine(nameof(FalseClick));
            }
        }
    }

    IEnumerator FalseClick()
    {
        //Cant click consecutive
        isOnClick = true;

        float newY;
        Vector3 newPos;
        float speed = 10;
        
        newY = spriteSuitcase.transform.position.y + 1f;
        while (spriteSuitcase.transform.position.y <= newY)
        {
            spriteSuitcase.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // ring
        float speedRotate = 300f;
        while (spriteSuitcase.transform.eulerAngles.z <= 25)
        {
            spriteSuitcase.transform.eulerAngles += new Vector3 (0, 0 , speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (spriteSuitcase.transform.eulerAngles.z > 0 && spriteSuitcase.transform.eulerAngles.z <= 180)
        {
            spriteSuitcase.transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }        
        
        while (spriteSuitcase.transform.eulerAngles.z >= 360 - 25)
        {
            spriteSuitcase.transform.eulerAngles -= new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (spriteSuitcase.transform.eulerAngles.z <= 360 && spriteSuitcase.transform.eulerAngles.z >= 180)
        {
            spriteSuitcase.transform.eulerAngles += new Vector3(0, 0, speedRotate * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.eulerAngles = Vector3.zero;


        // Move Down
        newY = spriteSuitcase.transform.position.y - 1f;
        while (spriteSuitcase.transform.position.y >= newY)
        {
            spriteSuitcase.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        spriteSuitcase.transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Complete onClick
        isOnClick = false;
    }
}
