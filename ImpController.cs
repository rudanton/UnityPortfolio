using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpController : Monster
{
    float moveSpeed;
    Vector3 dir;
    Vector3 normalDir;
    float coolTime, attackTime;
    float walkV, RunV;
    public Transform target;
    bool stop;
    public float attackDamage;
    
    private void OnEnable()
    {
        stop = false;
        walkV = 0.7f;
        RunV = 1.0f;
        primaryHP = 150;
        HP = primaryHP;
        moveSpeed = 4f;
        coolTime = 0f;
        attackDamage = 7f;
    }
    private void Update()
    {
        //상태설정.
        #region
        dir = target.position - gameObject.transform.position;
        normalDir = dir.normalized;
        float dot = Vector3.Dot(normalDir, gameObject.transform.forward);
        if (dir.magnitude < 5f && dot > 0.4)
        {
            state = State.RUN;
            //LookForward();
        }
        else stop = false;
        if (state != State.IDLE && state != State.WALK && dir.magnitude > 7f)
        {
            stop = false;
            state = State.WALK;
        }
        if (dir.magnitude < 1.5f && state == State.RUN)
        {
            stop = true;
            state = State.ATTACK;
            attackTime = 0;
        }
        else attackTime = 3f;

        switch (state)
        {
            case State.IDLE:
                Idle();
                break;
            case State.WALK:
                Walk();
                break;
            case State.RUN:
                LookForward();
                Run();
                break;
            case State.ATTACK:
                Attack();
                break;
            case State.DEAD:
                gameObject.transform.Translate(Vector3.zero);
                break;
        }
        #endregion
    }
    //상태별 함수.
    #region
    void Walk()
    {
        coolTime += Time.deltaTime;
        gameObject.transform.Translate(Vector3.forward * walkV * moveSpeed * Time.deltaTime);
        anim.SetFloat("Move", walkV);
        if(coolTime >5)
        {
            state = State.IDLE;
            coolTime = 0;
        }
    }

    void Idle()
    {
        coolTime += Time.deltaTime;
        anim.SetFloat("Move", 0);
        if (coolTime > 6.5f)
        {
            gameObject.transform.Rotate(Vector3.up, 180f);
            state = State.WALK;
            coolTime = 0;
        }
    }

    void Attack()
    {
        coolTime += Time.deltaTime;
        LookForward();
        anim.SetFloat("Move", 0);
        gameObject.transform.Translate(Vector3.zero);
        if (coolTime >= attackTime)
        {
            anim.SetTrigger("Attack");
            coolTime = 0;
            attackTime = 4;
        }
        StartCoroutine("DelayTime");
    }

    void Run()
    {
        coolTime = 0;
        anim.SetFloat("Move", RunV);
        if(!stop)
        {
            gameObject.transform.Translate(Vector3.forward * RunV * moveSpeed * Time.deltaTime);
        }
    }

    void LookForward()
    {
        Vector3 yRot = new Vector3(dir.x, gameObject.transform.position.y, dir.z);
        yRot = yRot.normalized;
        gameObject.transform.forward = yRot;
    }
    #endregion

    //피격, 사망 애니메이션
    #region
    public override void GetDamage(float damage, Vector3 LookCollider)
    {
        anim.SetFloat("Damage", damage);
        anim.SetTrigger("OnHit");
        base.GetDamage(damage, LookCollider);
        state = State.ATTACK;
    }
    protected override void Die()
    {
        state = State.DEAD;
        base.Die();
        anim.SetBool("Dead", dead);
        StartCoroutine(Disappear());
    }
    IEnumerator Disappear()
    {
        rdr.material.color = new Vector4(0, 0, 0, 0.5f);
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

    #endregion

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(2f);
    }

    

}




//private void Invisible()
//{
//    StartCoroutine("DelayTime");
//    color.a -= 0.001f;
//    rdr.material.color = color;
//    if (rdr.material.color.a <= 0) gameObject.SetActive(false);
//}
//IEnumerator DelayTime()
//{
//    yield return new WaitForSeconds(1f);
//}