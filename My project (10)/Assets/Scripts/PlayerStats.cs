using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   
    public static PlayerStats playerStats;
    public GameObject player;

    public float health;
    public float maxhealth;

    private void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxhealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    public void HealCharacter(float damage)
    {
        health += damage;
        CheckOverHeal();
    }

    public void CheckDeath()
    {
        if(health <= 0)
        {
            Destroy(player);
        }
    }

    public void CheckOverHeal()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }
}
