using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingOrganism : MonoBehaviour, IDamageable
{
    protected float primaryHP;
    public float HP { get; protected set; }
    protected float heal;
    public bool dead {get; protected set; }
    
    public virtual void GetDamage(float damage, Vector3 LookCollider)
    {
        Vector3 target = new Vector3(LookCollider.x, gameObject.transform.position.y, LookCollider.z);
        gameObject.transform.LookAt(target);
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            Die();
        }

    }
    protected virtual void healByRest()
    {
        HP += heal;
    }
    protected virtual void Die()
    {
        dead = true;
    }
}
