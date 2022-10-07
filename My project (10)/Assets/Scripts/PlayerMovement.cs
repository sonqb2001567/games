using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] BaseInventory inventory;
    public Camera cam;
    [SerializeField] BasePlayer basePlayer;
    Vector2 movement, mp;
    Vector3 mousePos;
    [SerializeField] float speed;
    public Rigidbody2D rb;
    public Rigidbody2D firepoint;
    public List<GameObject> weaponList;
    private Dictionary<string, GameObject> weaponDict = new Dictionary<string, GameObject>();
    PlayerStats stats;
    ObjectPooler objectPooler;
   
    private void Start()
    {
        speed = basePlayer.speed;
        stats = GameObject.Find("GameManager").GetComponent<PlayerStats>();
        objectPooler = ObjectPooler.instance;
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponDict.Add(weaponList[i].name, weaponList[i]);
        }    
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
        if (collision.tag == "Drop")
        {
            collision.gameObject.SetActive(false);
            objectPooler.poolDictionary[collision.tag].Enqueue(collision.gameObject);
            stats.GainExp(10);
        }

        if (collision.tag == "Drop1")
        {
            collision.gameObject.SetActive(false);
            objectPooler.poolDictionary[collision.tag].Enqueue(collision.gameObject);
            stats.GainExp(15);
        }

        if (collision.tag == "Drop2")
        {
            collision.gameObject.SetActive(false);
            objectPooler.poolDictionary[collision.tag].Enqueue(collision.gameObject);
            stats.GainExp(30);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            stats.DealDamage(20);
        }
    }

    public void EquipWeapon(string target)
    {
        GameObject go = Instantiate(weaponDict[target], rb.position, Quaternion.identity);
        go.transform.parent = GameObject.Find("Player").transform;
        inventory.AddWeapons(weaponDict[target]);
    }

    private void OnApplicationQuit() => inventory.ClearInventory();
}
