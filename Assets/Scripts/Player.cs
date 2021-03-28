using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingOrganism
{
    /*
    public bool dead {get; protected set; }

    public virtual void GetDamage(float damage)
    {
        if (HP > 0)
        {
            HP -= damage;
        }
        else Die();
    }
    protected virtual void healByRest()
    {
        HP += heal;
    }
    protected virtual void Die()
    {
        dead = true;
    }
    
     */
    protected CharacterController cc;
    protected PlayerAttack pa;
    protected Color originColor;
    protected Animator anim;
    protected SkinnedMeshRenderer rdr;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        pa = FindObjectOfType<PlayerAttack>();
        rdr = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponentInChildren<Animator>();
        originColor = rdr.material.color;
        primaryHP = 200f;
        HP = primaryHP;
        heal = 0;
        anim.SetBool("Recovery", true);
    }
    protected override void Die()
    {
        base.Die();
    }
    public override void GetDamage(float damage, Vector3 LookCollider)
    {
        if(anim.GetBool("Recovery"))
        {
            base.GetDamage(damage, LookCollider);
            anim.SetTrigger("GetHit");
            anim.SetFloat("Damage", damage);
            StartCoroutine("HitRecovery");
        }
    }
    protected override void healByRest()
    {
        base.healByRest();
    }
    IEnumerator HitRecovery()
    {
        anim.SetBool("Recovery", false);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Recovery", true);
    }

}
