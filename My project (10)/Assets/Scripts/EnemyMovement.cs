using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector2 movement, playerPos;
    public Transform player;
    public int speed;

    // Start is called before the first frame update
    void Update()
    {
        movement.x = gameObject.transform.position.x;
        movement.y = gameObject.transform.position.y;

        playerPos = player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + (playerPos - movement).normalized * speed * Time.fixedDeltaTime);
     
    }
}
