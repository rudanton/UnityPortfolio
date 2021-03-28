using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAttackCollision : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }
    IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        ImpController ic = FindObjectOfType<ImpController>();
        //IDamageable target = other.GetComponent<IDamageable>();s
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetDamage(ic.attackDamage, gameObject.transform.position);
        }
    }
}
