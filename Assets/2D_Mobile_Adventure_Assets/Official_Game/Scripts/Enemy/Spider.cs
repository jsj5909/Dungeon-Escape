using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int Health { get ; set ; }

    public GameObject acidEffectPrefab;
   
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Movement()
    {
       
    }


    public void Damage()
    {
        Health--;
        
        if (Health < 1)
            Destroy(this.gameObject);
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

}
