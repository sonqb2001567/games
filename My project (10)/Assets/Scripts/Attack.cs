using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float shootingTime = 0f;
    float timeCounter;

    Vector2 mousePos;
    // Update is called once per frame
    private void Start()
    {
        timeCounter = 0f;
    }

    void Update()
    {
        if (timeCounter % shootingTime == 0)
        {
            Shoot();
        }
        timeCounter++;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
