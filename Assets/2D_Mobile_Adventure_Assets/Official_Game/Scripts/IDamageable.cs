using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{

    public int Health  //auto property
    {
        get; set;
    }

    void Damage();

}
