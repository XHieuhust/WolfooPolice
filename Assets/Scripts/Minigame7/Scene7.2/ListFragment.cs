using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListFragment : MonoBehaviour
{
    [SerializeField] List<Sprite> ListSprites;
    
    int cnt_Fragment;

    public void FlyOut(float scale)
    {
        int cnt = 0;
        for(int i = 0; i < ListSprites.Count; ++i)
        {
            GameObject ob = new GameObject();
            ob.AddComponent<Rigidbody2D>();
            ob.AddComponent<SpriteRenderer>();
            ob.GetComponent<SpriteRenderer>().sprite = ListSprites[i];
            ob.GetComponent<SpriteRenderer>().sortingOrder = 10;
            ob.transform.position = transform.position;
            float direct = (2 * Mathf.PI / ListSprites.Count) * cnt;
            cnt++;
            StartCoroutine(StartFly(ob, direct));
        }
    }

    IEnumerator StartFly(GameObject ob, float direct)
    {
        float speed = 20f;
        ob.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(direct), 1).normalized * speed;
        yield return new WaitForSeconds(1f);
        UpdateFragmentDestroy();
        Destroy(ob);
    }

    void UpdateFragmentDestroy()
    {
        cnt_Fragment++;
        if (cnt_Fragment == ListSprites.Count)
        {
            Destroy(gameObject);
        }
    }
} 
