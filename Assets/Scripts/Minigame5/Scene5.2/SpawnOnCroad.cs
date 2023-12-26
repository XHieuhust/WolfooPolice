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
    [SerializeField] bool isLeft;
    private void OnEnable()
    {
        SteeringWheel.eGetGoalPos += End;
    }
    private void OnDestroy()
    {
        SteeringWheel.eGetGoalPos -= End;

    }
    private void Start()
    {
        StartCoroutine(nameof(SpawnThingOnRoad));
    }


    IEnumerator SpawnThingOnRoad()
    {
        while (isLeft || !GameScene52Manager.ins.isEndGame)
        {
            float scale = GameScene52Manager.ins.scaleSpeed;
            ThingOnRoad thing = Instantiate(ListOfThings[(amountSpawned++) % ListOfThings.Count], startSpawn.position, Quaternion.identity);
            thing.StartMove(startSpawn, endSpawn, posMaxScale);
            yield return new WaitForSeconds(timeSpawn / scale);
        }
    }
    
    private void End()
    {
        StopCoroutine(nameof(SpawnThingOnRoad));
    }

}
