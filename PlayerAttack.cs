using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    Animator anim;
    public bool Move { get; private set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Armed", false);
    }
    //Armed
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (anim.GetBool("Armed")) anim.SetBool("Armed", false);
            else anim.SetBool("Armed", true);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if (!anim.GetBool("Armed")) anim.SetBool("Armed", true);
            else
            {
                anim.SetTrigger("Attack");
            }
        }
    }
    public void OnCombat()
    {
        Move = false;
    }
    public void UnderCombat()
    {
        Move = true;
    }
}
