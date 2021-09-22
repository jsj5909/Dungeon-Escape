using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    int IDamageable.Health { get ; set; }

    public void Damage()
    {
       
    }

    public override void Init()
    {
        base.Init();
    }

 


}


   
