using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImpController : Monster
{
    float moveSpeed;
    Vector3 dir;
    Vector3 normalDir;
    float coolTime, attackTime;
    float walkV, RunV;
    bool stop;
    public float attackDamage;
    public Slider slider;
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
        rdr.material.color = originColor;
    }
    private void Update()

    {
        //slider.gameObject.SetActive(true);
        slider.maxValue = primaryHP;
        slider.value = HP;
        //상태설정.
        #region
        dir = target.position - gameObject.transform.position;
        normalDir = dir.normalized;
        float dot = Vector3.Dot(normalDir, gameObject.transform.forward);
        if(!dead)
        {
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
                attackTime = Time.time - 3;
            }
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
                    gameObject.transform.forward = gameObject.transform.forward;
                    break;
                case State.HIT:
                    break;
            }
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
        LookForward();
        anim.SetFloat("Move", 0);
        gameObject.transform.Translate(Vector3.zero);
        if (Time.time - attackTime >= 1.5f)
        {
            anim.SetTrigger("Attack");
            coolTime = 0;
            attackTime = Time.time;
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
        base.GetDamage(damage, LookCollider);
        state = State.HIT;
        anim.SetFloat("Damage", damage);
        anim.SetTrigger("OnHit");
        state = State.ATTACK;
    }
    protected override void Die()
    {
        base.Die();
        state = State.DEAD;
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

    

}
