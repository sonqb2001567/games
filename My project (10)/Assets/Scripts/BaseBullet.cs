using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
   public virtual void HittingEnemy(Collider2D enemy) { }
}
