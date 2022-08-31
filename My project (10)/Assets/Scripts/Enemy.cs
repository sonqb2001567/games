using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    Vector2 movement, playerPos;
    public Transform player;
    public int speed;
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
        player = GameObject.Find("Player").transform;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "bullet")
        {
            gameObject.SetActive(false);
            objectPooler.poolDictionary[gameObject.tag].Enqueue(gameObject);
            OnObjectDespawn();
        }
    }

    public void OnObjectDespawn()
    {
        GameObject newDrop = objectPooler.SpawnFromPool("Drop");
        newDrop.transform.position = gameObject.transform.position;
    }
}
