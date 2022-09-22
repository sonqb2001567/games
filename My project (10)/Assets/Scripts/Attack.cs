using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform secondFP;
    ObjectPooler objectPooler;

    private int xVal, yVal;
    private float randomAngle;
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
            RandomShot();
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
           
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void RandomShot()
    {
        GameObject bullet = objectPooler.SpawnFromPool("bullet2");

        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;

        }

        secondFP.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        Vector2 randomPos = new Vector3(xVal * Random.Range(1, 3), yVal * Random.Range(1, 3));

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(secondFP.up * bulletForce, ForceMode2D.Impulse);
    }

}
