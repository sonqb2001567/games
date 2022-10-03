using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player", menuName ="New Player")]
public class BasePlayer : ScriptableObject
{
    public int maxHealth;
    public int health;
    public int speed;
    [SerializeField]
    List<string> weaponList;
    public List<int> exp;
    public int currentExp;
}
