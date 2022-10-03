using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public int speed;
    public int activeTime;
    private int count = 0;
    int damage;
    ObjectPooler objectPooler;

    public void SetDamage(int s)
    {
        damage = s;
    }

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    private void FixedUpdate()
    {
        if (count == activeTime)
        {
            gameObject.SetActive(false);
            objectPooler.poolDictionary[gameObject.tag].Enqueue(gameObject);
            count = 0;
        }
        count++;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag != "Player" & other.tag != "Drop" & other.tag != "bullet")
        {
            gameObject.SetActive(false);
            objectPooler.poolDictionary[gameObject.tag].Enqueue(gameObject);
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    public void OnObjectDespawn()
    {
        
    }
}
