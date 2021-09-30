using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _animator;

    private Animator _swordArcAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _swordArcAnimator = transform.GetChild(1).GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
      
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }
    public void Land()
    {
        _animator.SetBool("Jumping", false);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordArcAnimator.SetTrigger("Sword Animation");
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
    }

}
