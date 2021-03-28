using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    PlayerAttack pa;
    public GameObject box;
    public AudioSource audioSource;
    public AudioClip[] attack;
    void Awake()
    {
        pa = FindObjectOfType<PlayerAttack>();
        audioSource = GetComponent<AudioSource>();
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
