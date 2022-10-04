using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : BaseWeapon
{
    ObjectPooler objectPooler;
   
    public Weapon weapon;
    public int bulletForce;
    public int shootingTime;
    public Transform secondFP;
    public Transform firePoint;
    public int damage;

    private int xVal, yVal;
    private float timeCounter;

    private void Start()
    {
        bulletForce = weapon.bulletForce;
        shootingTime = weapon.delay;
        damage = weapon.damage;
        objectPooler = ObjectPooler.instance;
        secondFP = GameObject.Find("2nd Fire Point").transform;
        firePoint = GameObject.Find("Fire Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter == shootingTime)
        {
            RandomShot();
            timeCounter = 0f;
        }
        timeCounter++;
    }

    void RandomShot()
    {
        GameObject bullet = objectPooler.SpawnFromPool("bullet2");
        bullet.GetComponent<Bullet>().source = this.gameObject;
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

    public override int GetDamage() => damage;
}
