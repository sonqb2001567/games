using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FirePalmAbility : Ability
{
    [SerializeField] float hitRadius;
    [SerializeField] CircleCollider2D collider;
    [SerializeField] ContactFilter2D filter;
    [SerializeField] int damage;

    public override void Casting(GameObject go)
    {
        Debug.Log("FirePalm");
        //collider.transform.SetParent(go.transform);
        //Collider2D[] result = new Collider2D[100];
        //collider.radius = hitRadius;
        //collider.OverlapCollider(filter, result);
        //for (int i = 0; i < result.Length; i++)
        //{
        //    result[i].gameObject.GetComponent<Zombie>().TakeDamage(damage);
        //}
    }
}
