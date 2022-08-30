using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    ObjectPooler objectPooler;

    public float bulletForce = 20f;
    public float shootingTime = 0f;
    float timeCounter;

    Vector2 mousePos;
    // Update is called once per frame
    private void Start()
    {
        objectPooler = ObjectPooler.instance;
        timeCounter = 0f;
    }

    void Update()
    {
        if (timeCounter == shootingTime)
        {
            Shoot();
            timeCounter = 0f;
        }
        timeCounter++;
    }

    void Shoot()
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        GameObject bullet = objectPooler.SpawnFromPool("bullet");
        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
