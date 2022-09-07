using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;
    public GameObject player;

    public float health;
    public float maxhealth;

    private List<int> exp = new List<int>{30, 50, 90, 170};
    private int currentExp;
    private int count = 0;
    private UIController uiControler;

    #region Singleton
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
    #endregion

    void Start()
    {
        health = maxhealth;
        uiControler = UIController.instance;
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
            player.GetComponent<SpriteRenderer>().enabled = false;
            uiControler.OpenUI("EndGamePanel");
            Time.timeScale = 0;
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
