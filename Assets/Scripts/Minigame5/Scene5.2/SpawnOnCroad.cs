using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCroad : MonoBehaviour
{
    [SerializeField] List<ThingOnRoad> ListOfThings;
    int amountSpawned;
    [SerializeField] float timeSpawn;
    [SerializeField] Transform startSpawn;
    [SerializeField] Transform endSpawn;
    [SerializeField] Transform posMaxScale;
    private void Start()
    {
        StartCoroutine(nameof(SpawnThingOnRoad));
    }


    IEnumerator SpawnThingOnRoad()
    {
        while (true && !GameScene52Manager.ins.isEndGame)
        {
            float scale = GameScene52Manager.ins.scaleSpeed;
            ThingOnRoad thing = Instantiate(ListOfThings[(amountSpawned++) % ListOfThings.Count], startSpawn.position, Quaternion.identity);
            thing.StartMove(startSpawn, endSpawn, posMaxScale);
            yield return new WaitForSeconds(timeSpawn / scale);
        }
    }
    

}
