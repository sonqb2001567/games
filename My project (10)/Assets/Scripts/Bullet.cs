using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int count = 0;
    ObjectPooler objectPooler;
    
    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos.z = 0;
    //    mousePos = myCamera.transform.TransformPoint(mousePos);
    //    gameObject.GetComponent<Rigidbody2D>().velocity = (mousePos - gameObject.GetComponent<Transform>().position).normalized * bulletSpeed;
    //    Debug.Log(mousePos);
    }

    private void FixedUpdate()
    {
        if (count == 100)
        {
            gameObject.SetActive(false);
            objectPooler.poolDictionary[gameObject.tag].Enqueue(gameObject);
            count = 0;
        }
        count++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
