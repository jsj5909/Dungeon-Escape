using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get ; set; }

    public void Damage()
    {
        Debug.Log("Moss Giant Damamge");

        Health--;

        animator.SetTrigger("Hit");

        isHit = true;

        animator.SetBool("InCombat", true);

        if (Health < 1)
            Destroy(gameObject);


    }

    public override void Init()
    {
        Health = base.health;
        
        base.Init();
    }

 


}


   
