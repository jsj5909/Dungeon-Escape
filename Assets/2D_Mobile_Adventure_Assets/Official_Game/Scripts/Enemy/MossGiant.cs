using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get ; set; }

    [SerializeField]
    private GameObject _diamondPrefab;

    public void Damage()
    {
        Debug.Log("Moss Giant Damamge");


        if (isDead == true)
            return;

        Health--;

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

    public override void Init()
    {
        Health = base.health;
        
        base.Init();
    }

 


}


   
