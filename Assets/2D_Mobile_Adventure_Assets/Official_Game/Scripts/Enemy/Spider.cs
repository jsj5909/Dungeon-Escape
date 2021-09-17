using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private bool _movingtoA;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;



        Movement();


    }

    private void Movement()
    {
        if (_target == pointA.position)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            _target = pointB.position;
            _animator.SetTrigger("Idle");

        }
        else
        if (transform.position == pointB.position)
        {
            _target = pointA.position;
            _animator.SetTrigger("Idle");

        }


        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
