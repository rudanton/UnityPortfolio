using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform target;
    private void Awake()
    {
        target = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.forward = target.forward;
    }
}
