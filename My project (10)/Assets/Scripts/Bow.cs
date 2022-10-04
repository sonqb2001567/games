using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public Weapon weapon;
    public ObjectPooler objectPooler;
    public Transform firePoint;
    public int bulletForce;
    public int shootingTime;
    public int damage;

    private float timeCounter;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
        firePoint = GameObject.Find("Fire Point").transform;
        bulletForce = weapon.bulletForce;
        shootingTime = weapon.delay;
        damage = weapon.damage; 
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
        GameObject bullet = objectPooler.SpawnFromPool(weapon.bullet);
        bullet.GetComponent<Bullet>().source = this.gameObject;
        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;

        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public override int GetDamage() => damage;
}
