using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    // Start is called before the first frame update
    

    void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }
    IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        //IDamageable target = other.GetComponent<IDamageable>();
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Monster>().GetDamage(pc.attackDamage, gameObject.transform.position);
        }
    }
}
