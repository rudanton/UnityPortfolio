using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    PlayerAttack pa;
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
}
