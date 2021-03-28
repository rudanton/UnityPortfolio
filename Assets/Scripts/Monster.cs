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
        HIT,
        ATTACK,
        RETURN,
        DEAD
    }
    protected State state;


    protected Animator anim;
    protected SkinnedMeshRenderer rdr;
    public Transform target;
    protected Color originColor;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rdr = GetComponentInChildren<SkinnedMeshRenderer>();
        target = FindObjectOfType<Player>().transform;
        originColor = rdr.material.color;
    }
    public override void GetDamage(float damage, Vector3 LookCollider)
    {
        if (!dead)
        {
            base.GetDamage(damage, LookCollider);
            StartCoroutine(OnHit());
        }
    }
    private IEnumerator OnHit()
    {
        yield return new WaitForSeconds(0.7f);
    }
    
}
