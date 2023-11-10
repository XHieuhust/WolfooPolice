using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    [SerializeField] float disRoad;
    [SerializeField] List<GameObject> ListDoChoi;
    [SerializeField] List<GameObject> ListObsacles;
    [SerializeField] float TimeSpawnObsacle;
    [SerializeField] float TimeSpawnToy;
    [SerializeField] GameObject thief;
    [SerializeField] List<Vector3> SpawnPositions;
    public bool isCanSpawn = true;
    public static SpawnThings ins;
    float curY;
    void Start()
    {
        ins = this;
    }

    public IEnumerator RandomSpawnToys()
    {
        while (true)
        {
            FallToys();
            yield return new WaitForSeconds(TimeSpawnToy);
        }
    }

    public IEnumerator RandomSpawnObsalce()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawnObsacle);
            FallObsalces();
        }

    }

    int cntObsacles;
    void FallObsalces()
    {
        int ran;
        if (thief.transform.position.y > transform.position.y)
        {
            ran = Random.Range(0, 2);
            Vector3 ObsaclePosition = new Vector3(transform.position.x, SpawnPositions[ran].y, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
        else if (thief.transform.position.y == transform.position.y)
        {
            ran = Random.Range(0, 2) == 0 ? 0 : 2;
            Vector3 ObsaclePosition = new Vector3(transform.position.x, SpawnPositions[ran].y, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
        else if (thief.transform.position.y < transform.position.y)
        {
            ran = Random.Range(1, 3);
            Vector3 ObsaclePosition = new Vector3(transform.position.x, SpawnPositions[ran].y, transform.position.z);
            Instantiate(ListObsacles[cntObsacles++ % 3], ObsaclePosition, Quaternion.identity);
        }
    }

    int cntToys;
    void FallToys()
    {
        // fall from thief to road
        Vector3 fallPosition = new Vector3(thief.transform.position.x - 1f, thief.GetComponent<Thief>().newY + 2f, thief.transform.position.z);
        Instantiate(ListDoChoi[(cntToys++) % 6], fallPosition, Quaternion.identity);
    }

    public void StopToSpawn()
    {
        StopAllCoroutines();
    }

    public void StartToSpawn()
    {
        if (isCanSpawn)
        {
            StartCoroutine(nameof(RandomSpawnToys));
            StartCoroutine(nameof(RandomSpawnObsalce));
        }

    }
}
