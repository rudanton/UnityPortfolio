using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Target;

    float mx, my;
    float rotSpeed = 200;

    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Target.transform.position;


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);
        transform.eulerAngles = new Vector3(-my, mx, 0f);
        //transform.rotation = Target.transform.rotation;
    }
}
