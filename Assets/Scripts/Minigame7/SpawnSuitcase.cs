using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSuitcase : MonoBehaviour
{
    [SerializeField] List<Sprite> Sprites;
    [SerializeField] Suitcase suitcase;
    [SerializeField] float timeSpawn;
    float eslapsed;
    float extras;
    int cnt;

    private void Start()
    {
        StartCoroutine(nameof(StartSpawn));
    }
    IEnumerator StartSpawn()
    {
        while (true)
        {
            extras = Time.deltaTime;
            eslapsed += extras;
            if (eslapsed >= timeSpawn)
            {
                Suitcase newSuit = Instantiate(suitcase, transform.position, Quaternion.identity);
                newSuit.SetUp(Sprites[cnt++], cnt++ % 8 == 0);
                eslapsed = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
