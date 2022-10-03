using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy, IPooledObject
{
    Vector2 movement, playerPos;
    public BaseEnemy baseEnemy;

    [SerializeField] int health;
    int speed;
    int damage;
    Transform player;
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
        player = GameObject.Find("Player").transform;
        speed = baseEnemy.speed;
        damage = baseEnemy.damage;
        health = baseEnemy.health;
    }

    void Update()
    {
        movement.x = gameObject.transform.position.x;
        movement.y = gameObject.transform.position.y;

        playerPos = player.position;
    }

    // Movement
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + (playerPos - movement).normalized * speed * Time.fixedDeltaTime);
     
    }

    public override void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health < 0)
        {
            this.gameObject.SetActive(false);
            objectPooler.poolDictionary[this.transform.tag].Enqueue(this.gameObject);
            OnObjectDespawn();
        }
    }

    public void OnObjectDespawn()
    {
        GameObject newDrop = objectPooler.SpawnFromPool("Drop");
        newDrop.transform.position = gameObject.transform.position;
    }
}
