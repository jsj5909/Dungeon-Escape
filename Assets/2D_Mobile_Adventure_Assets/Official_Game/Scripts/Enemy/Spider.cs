using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{
    public int Health { get ; set ; }

    public GameObject acidEffectPrefab;

    [SerializeField]
    private GameObject _diamondPrefab;

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
        if (isDead == true)
            return;
        
        Health--;

        if (Health < 1)
        {
            animator.SetTrigger("Death");
            isDead = true;


            GameObject di = Instantiate(_diamondPrefab, transform.position, Quaternion.identity);

            di.GetComponent<Diamond>().value = base.gems;


        }
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

}
