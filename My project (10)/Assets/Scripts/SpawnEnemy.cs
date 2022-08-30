using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int spawnTime;
    private int count;

    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    void Update()
    {
        if (count == spawnTime)
        {
            count = 0;
            SpawnAtRandom();
        }
        count++;
    }

    void SpawnAtRandom()
    {
        GameObject newEnemy = objectPooler.SpawnFromPool("Enemy1");
        Vector3 randomPos = new Vector3(Random.Range(0, 50), Random.Range(0, 50), 0);
        newEnemy.transform.position = GameObject.Find("Player").transform.position + randomPos;
        newEnemy.transform.rotation = Quaternion.identity;
    }
}
