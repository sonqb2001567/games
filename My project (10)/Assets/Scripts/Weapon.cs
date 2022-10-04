using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public string weaponType;

    public Sprite sprite;

    public string description;
    public int damage;
    public int bulletForce;
    public int delay;
    public float range;
    public string bullet;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] bool equiped;
}
