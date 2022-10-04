using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseBullet, IPooledObject
{
    public int speed;
    public int activeTime;
    private int count = 0;
    int damage;
    public GameObject source;
    ObjectPooler objectPooler;

    private void Start()
    {
        damage = source.GetComponent<BaseWeapon>().GetDamage();
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
        HittingEnemy(other);
    }

    public override void HittingEnemy(Collider2D other)
    {
        if (other.tag == "Enemy")
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
