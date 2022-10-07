using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;
    public GameObject player;
    public Image healthBar;
    public Image expBar;
    public GameEvent endGame;
    public float health;
    public float maxhealth;

    private List<float> exp = new List<float>{30, 60, 120, 240, 480, 960};
    private float currentExp;
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
        currentExp = 0;
        UpdateExp();
        UpdateHealth();
        uiControler = UIController.instance;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        UpdateHealth();
    }

    public void HealCharacter(float damage)
    {
        health += damage;
        CheckOverHeal();
        UpdateHealth();
    }

    public void CheckDeath()
    {
        if(health <= 0)
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            endGame.Invoke();
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
        UpdateExp();
        if (currentExp >= exp[count])
        {
            currentExp = 0;
            UpdateExp();
            count++;
            Debug.Log(count);
        }
    }

    public void UpdateExp() => expBar.fillAmount = (currentExp / exp[count]);
    

    public void UpdateHealth()
    {
        healthBar.fillAmount = health / maxhealth;
        if (healthBar.fillAmount < 0.5 && healthBar.fillAmount > 0.25)
        {
            healthBar.color= Color.yellow;
        }

        if (healthBar.fillAmount < 0.25 )
        {
            healthBar.color= Color.red; 
        }
    }
}
