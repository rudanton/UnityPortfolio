using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    PlayerAttack pa;
    public GameObject box;
    void Start()
    {
        pa = FindObjectOfType<PlayerAttack>();
    }
    void OnCombat()
    {
        pa.OnCombat();
    }
    void UnderCombat()
    {
        pa.UnderCombat();
    }
    void Attack()
    {
        box.SetActive(true);
    }
    
}
