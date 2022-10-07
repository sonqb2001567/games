using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite abilitySprite;
    public float coolDown;
    public float activeTime;

    public virtual void Activate(GameObject go) { }
}
