using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;
    public GameObject player;
    public GameObject endGameSc;

    public float health;
    public float maxhealth;

    private List<int> exp = new List<int>{30, 50, 90, 170};
    private int currentExp;
    private int count = 0;

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
        endGameSc = GameObject.Find("EndGameScene");
        endGameSc.SetActive(false);
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
            player.SetActive(false);
            endGameSc.SetActive(true);
        }
    }

    public void CheckOverHeal()
    {
        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }

    public void GainExp(int expOrb)
    {
        currentExp += expOrb;
        if (currentExp >= exp[count])
        {
            currentExp = 0;
            count++;
            Debug.Log(count);
        }
    }
}
