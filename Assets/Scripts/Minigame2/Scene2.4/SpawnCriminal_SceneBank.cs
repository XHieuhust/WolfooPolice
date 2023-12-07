using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCriminal_SceneBank : MonoBehaviour
{
    [SerializeField] Transform roadUp;
    [SerializeField] Transform roadUnder;
    [SerializeField] GameObject criminal;
    [SerializeField] GameObject criminalGun;
    [SerializeField] float timeSpawn;
    [SerializeField] float timeDelay1;
    [SerializeField] int maxInTurn;

    public delegate void SpawnCriminalGun();
    public static SpawnCriminalGun spawnCriminalGun;

    public void Start()
    {
        StartToSpawn();
    }

    private void OnEnable()
    {
        spawnCriminalGun += StartSpawnCriminalGun;
    }

    void InstantiateCriminal(GameObject typeCriminal, Transform road, float directX)
    {
        GameObject newCrim = Instantiate(typeCriminal, road.position, Quaternion.identity);
        newCrim.GetComponent<Criminal_SceneBank>().directX = directX;
        if (road == roadUnder)
        {
            newCrim.GetComponent<Criminal_SceneBank>().IncreaseOrderLayer();
        }
    }

    IEnumerator SpawnCriminal1()
    {
        int cnt = 0;
        int maxInTurn = 10;
        while (true)
        {
            InstantiateCriminal(criminal, roadUnder, -1);
            InstantiateCriminal(criminal, roadUp, 1);
            yield return new WaitForSeconds(timeDelay1);
            InstantiateCriminal(criminal, roadUnder, -1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminal2));
    }

    IEnumerator SpawnCriminal2()
    {
        int cnt = 0;

        while (true)
        {
            InstantiateCriminal(criminal, roadUp, 1);
            InstantiateCriminal(criminal, roadUnder, -1);
            yield return new WaitForSeconds(timeDelay1);
            InstantiateCriminal(criminal, roadUp, 1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminal1));

    }

    IEnumerator SpawnCriminalGun1()
    {
        int cnt = 0;
        while (cnt <= maxInTurn)
        {
            cnt++;
            InstantiateCriminal(criminalGun, roadUp, 1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminalGun2));
    }



    IEnumerator SpawnCriminalGun2()
    {
        int cnt = 0;
        while (cnt <= maxInTurn)
        {
            InstantiateCriminal(criminalGun, roadUnder, 1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminalGun1));

    }

    private void StartToSpawn()
    {
        StartCoroutine(nameof(SpawnCriminal1));
    }

    public void StartSpawnCriminalGun()
    {
        StartCoroutine(nameof(SpawnCriminalGun1));
    }
}
