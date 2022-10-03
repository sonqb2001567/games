using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int spawnTime;
    private int count;
    private int yVal, xVal;

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
            SpawnAtRandom("Zombie");
        }
        count++;
    }

    void SpawnAtRandom(string enemyName)
    {
        if (Random.value < 0.5f)
        {
            yVal = 1;
        }
        else
        {
            yVal = -1;
        }


        if (Random.value < 0.5f)
        {
            xVal = 1;
        }
        else
        {
            xVal = -1;
        }

        GameObject newEnemy = objectPooler.SpawnFromPool(enemyName);
        Vector3 randomPos = new Vector3(xVal*Random.Range(30, 50), yVal*Random.Range(30, 50), 0);

        newEnemy.transform.position = GameObject.Find("Player").transform.position + randomPos;
        newEnemy.transform.rotation = Quaternion.identity;
    }

}
