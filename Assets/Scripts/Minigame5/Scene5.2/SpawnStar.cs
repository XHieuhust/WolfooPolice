using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    [SerializeField] List<Transform> ListStartSpawns;
    [SerializeField] List<Transform> ListEndSpawns;

    [SerializeField] ThingOnRoad star;
    [SerializeField] Transform posMaxScale;
    [SerializeField] float timeSpawn;
    private void Start()
    {
        StartCoroutine(StartSpawnStar());
    }

    IEnumerator StartSpawnStar()
    {
        int random;
        while (!GameScene52Manager.ins.isEndGame)
        {
            float scale = GameScene52Manager.ins.scaleSpeed;
            random = Random.Range(0, ListStartSpawns.Count);
            ThingOnRoad newStar = Instantiate(star, ListStartSpawns[random].position, Quaternion.identity);
            newStar.StartMove(ListStartSpawns[random], ListEndSpawns[random], posMaxScale);
            yield return new WaitForSeconds(timeSpawn / scale);
        }
    }
}
