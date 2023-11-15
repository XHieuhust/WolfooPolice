using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCarChase : MonoBehaviour
{
    [SerializeField] List<Sprite> ListSpriteCars;
    [SerializeField] Image car;
    [SerializeField] List<Transform> ListPosSpawn;
    [SerializeField] float timeSpawn;
    private void Start()
    {
        StartSpawnCar();
    }
    void StartSpawnCar()
    {
        StartCoroutine(nameof(SpawnCar));
    }

    IEnumerator SpawnCar()
    {
        int random;
        int randomSprite;
        while (!PanelDuoiBat.ins.isEndGame || !PanelDuoiBat.ins.isStopGame)
        {
            random = Random.Range(0, ListPosSpawn.Count);
            randomSprite = Random.Range(0, ListSpriteCars.Count);
            Vector3 posSpawn = new Vector3(transform.position.x, ListPosSpawn[random].position.y , transform.position.z);
            Image newCar1 = Instantiate(car, posSpawn, Quaternion.identity, transform.parent);
            newCar1.sprite = ListSpriteCars[randomSprite];
            yield return new WaitForSeconds(3f);
            random += 1;
            randomSprite += 1;
            posSpawn = new Vector3(transform.position.x, ListPosSpawn[random % ListPosSpawn.Count].position.y, transform.position.z);
            Image newCar2 = Instantiate(car, posSpawn, Quaternion.identity, transform.parent);
            newCar2.sprite = ListSpriteCars[randomSprite % ListSpriteCars.Count];
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
