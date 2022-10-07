using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public GameObject player;
    string abilityName;
    Sprite abilitySprite;
    float coolDown;
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public KeyCode key;

    private void Start()
    {
        abilityName = ability.name;
        abilitySprite = ability.abilitySprite;
        this.GetComponentInChildren<Image>().sprite = abilitySprite;
    }

    public void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(player);
                    state = AbilityState.active;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }    
                else
                {
                    state = AbilityState.cooldown;
                    coolDown = ability.coolDown;
                }    
            break;
            case AbilityState.cooldown:
                if (coolDown > 0)
                {
                    coolDown -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}
