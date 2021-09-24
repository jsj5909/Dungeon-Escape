using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get ; set ; }

    public override void Init()
    {
        Health = base.health;
        
        base.Init();
    }


    public void Damage()
    {
        Health--;

        animator.SetTrigger("Hit");

        if (Health < 1)
            Destroy(gameObject);
    }

}
