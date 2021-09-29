using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    [SerializeField]
    private GameObject _diamondPrefab;

    public int Health { get ; set ; }

    public override void Init()
    {
        Health = base.health;
        
        base.Init();
    }


    public void Damage()
    {

        if (isDead == true)
            return;

        Health--;

        Debug.Log("Skeleton Hit");

        animator.SetTrigger("Hit");
        



        isHit = true;

        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");

            GameObject di = Instantiate(_diamondPrefab, transform.position, Quaternion.identity);

            di.GetComponent<Diamond>().value = base.gems;

        }


    }

}
