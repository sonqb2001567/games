using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite abilitySprite;
    public float coolDown;
    public float activeTime;
    public float castingTime;

    public virtual void Activate(GameObject go) { }
    public virtual void Casting(GameObject go) { }
    public virtual void InActive(GameObject go) { } 
    public virtual void DeActive(GameObject go) { }
}
