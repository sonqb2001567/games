using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : BaseBullet
{
    float timeCounter = 0;

    public float speed;
    public float width;
    public float height;
    public int damage;
    [SerializeField] Weapon weapon;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speed = 5;
        width = 4;
        height = 4;
        damage = weapon.damage;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.transform.position;
        timeCounter += Time.deltaTime * speed;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = 0;

        transform.position += new Vector3(x, y, z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HittingEnemy(collision);
    }

    public override void HittingEnemy(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
