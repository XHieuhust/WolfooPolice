using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCuop : MonoBehaviour
{
    [SerializeField] Transform roadUp;
    [SerializeField] Transform roadUnder;
    [SerializeField] GameObject cuop;
    [SerializeField] GameObject cuopCoSung;
    [SerializeField] float timeSpawnCuop;

    public void Start()
    {
        StartToSpawn();
    }

    void InstantiateCuop(GameObject typeCuop, Transform road, float directX)
    {
        GameObject cuopSpawn = Instantiate(typeCuop, road.position, Quaternion.identity);
        cuopSpawn.GetComponent<Cuop>().directX = directX;
    }

    IEnumerator SpawnCuop1()
    {
        while (true)
        {
            InstantiateCuop(cuop, roadUnder, -1);
            yield return new WaitForSeconds(1.5f);
            InstantiateCuop(cuop, roadUnder, -1);
            yield return new WaitForSeconds(timeSpawnCuop);
        }
    }

    IEnumerator SpawnCuop2()
    {
        while (true)
        {
            InstantiateCuop(cuop, roadUp, 1);
            InstantiateCuop(cuopCoSung, roadUp, 1);
            yield return new WaitForSeconds(timeSpawnCuop);
        }
    }

    void StartToSpawn()
    {
        StartCoroutine(SpawnCuop1());
        StartCoroutine(SpawnCuop2());

    }
}
