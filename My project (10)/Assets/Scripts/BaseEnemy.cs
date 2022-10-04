using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="New Enemy")]
public class BaseEnemy : ScriptableObject
{
    public string enemyName;
    public Sprite sprite;
    public int speed;
    public int health;
    public int damage;
    public string tagFromPool;
}
