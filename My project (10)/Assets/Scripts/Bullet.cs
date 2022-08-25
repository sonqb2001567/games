using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;
    private int count = 0;

    
    //private void Start()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos.z = 0;
    //    mousePos = myCamera.transform.TransformPoint(mousePos);
    //    gameObject.GetComponent<Rigidbody2D>().velocity = (mousePos - gameObject.GetComponent<Transform>().position).normalized * bulletSpeed;
    //    Debug.Log(mousePos);
    //}
    private void FixedUpdate()
    {
        if (count == 100)
        {
            Destroy(gameObject);
            count = 0;
        }
        count++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
