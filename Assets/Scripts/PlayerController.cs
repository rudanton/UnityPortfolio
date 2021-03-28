using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    Vector3 dir;

    public float speed = 7f;
    public float jumpPower = 10f;
    public float gravity = -20f;

    float skid = 0f;
    float dash = 1f;
    public float attackDamage;

    float yVelocity=0f;
    float rotSpeed = 200f;
    float mx;
    
    // Update is called once per frame
    void Update()
    {
        #region
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");

        //캐릭터 회전.
        mx += mouseX * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);

        dir = new Vector3(h, 0 ,v);
        dir = dir.normalized;

        anim.SetFloat("MovingZ", dir.z, 0.15f, Time.deltaTime);
        anim.SetFloat("MovingX", dir.x, 0.15f, Time.deltaTime);

        dir = Camera.main.gameObject.transform.TransformDirection(dir);
        
        
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        if (Input.GetKey(KeyCode.LeftShift) && anim.GetFloat("MovingZ")>0.5)
        {
            dash = 1.8f;
            anim.SetBool("Dash", true);
            attackDamage = 15f;
        }
        else
        {
            dash = 1;
            anim.SetBool("Dash", false);
            attackDamage = 10f;
        }
        if(pa.Move)
        {
            cc.Move(dir * speed * dash * Time.deltaTime);
        }

        if ((dir.z>=0.5 || anim.GetBool("Dash")) && !pa.Move)
        {
            float skidV = speed * dash;
            cc.Move(dir * Time.deltaTime * (skidV - skid));
            if (skidV > skid)
            {
                skid += 0.2f;
            }
            else
            {
                skid = skidV;
            }
        }
        else skid = 0f;

        if (cc.isGrounded) yVelocity = 0;
        

        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            yVelocity = jumpPower;
            anim.SetTrigger("Jumping");
        }
        anim.SetBool("IsGrounded", cc.isGrounded);
        #endregion

    }
    
}
