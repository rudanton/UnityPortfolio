using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingOrganism : MonoBehaviour, IDamageable
{
    float primaryHP;
    float HP;
    float heal;
    public bool dead { get; private set; }

    void Awake()
    {
        HP = primaryHP;

    }
    public virtual void GetDamage(float damage)
    {

    }
    protected virtual void healByRest()
    {

    }
    protected virtual void Die()
    {

    }
}
