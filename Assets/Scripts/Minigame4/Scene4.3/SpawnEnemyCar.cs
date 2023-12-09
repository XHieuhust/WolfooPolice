using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemyCar : MonoBehaviour
{
    [SerializeField] float timeSpawn;
    [SerializeField] List<Image> ListEnemyCars;
    [SerializeField] List<Transform> ListPosSpawn;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        int maxCar = ListEnemyCars.Count;
        int maxPos = ListPosSpawn.Count;
        int cnt_car;
        int cnt_pos;
        while (true)
        {
            cnt_car = Random.Range(0, maxCar);
            cnt_pos = Random.Range(0, maxPos);
            Instantiate(ListEnemyCars[cnt_car], ListPosSpawn[cnt_pos].position, Quaternion.Euler(0, 180 ,0), transform);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
