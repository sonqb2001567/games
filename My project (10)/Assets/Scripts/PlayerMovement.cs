using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    Vector2 movement, mp;
    Vector3 mousePos;
    float speed = 5f;
    public Rigidbody2D rb;
    public Rigidbody2D firepoint;
    
    PlayerStats stats;
    ObjectPooler objectPooler;
   
    private void Start()
    {
        stats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        objectPooler = ObjectPooler.instance;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mp.x = mousePos.x;
        mp.y = mousePos.y;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
       
        Vector2 lookDir =  mp - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firepoint.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy1")
        {
            stats.DealDamage(10);
        }    

        if (collision.tag == "Drop")
        {
            collision.gameObject.SetActive(false);
            objectPooler.poolDictionary[collision.tag].Enqueue(collision.gameObject);
            stats.GainExp(10);
        }
    }
}
