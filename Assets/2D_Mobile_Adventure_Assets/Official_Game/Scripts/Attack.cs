using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    [SerializeField]
    private float _damageCooldownTime = 0.5f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && _canDamage)
        {
            hit.Damage();
            _canDamage = false;
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(_damageCooldownTime);
        _canDamage = true;
    }
}
