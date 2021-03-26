using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : LivingOrganism
{
    protected enum State
    {
        IDLE,
        WALK,
        RUN,
        ATTACK,
        RETURN,
        DEAD
    }
    protected State state;


    protected Animator anim;
    protected SkinnedMeshRenderer rdr;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        rdr = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    public override void GetDamage(float damage, Vector3 LookCollider)

    {
        base.GetDamage(damage, LookCollider);
        StartCoroutine(OnHit());
    }
    private IEnumerator OnHit()
    {
        yield return new WaitForSeconds(0.7f);
    }
    
}
