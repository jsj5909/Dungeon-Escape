using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    protected bool isHit = false;

    protected Transform player;

    [SerializeField]
    protected Transform pointA, pointB;

    protected bool movingtoA;

    protected Animator animator;

    protected SpriteRenderer spriteRenderer;

    protected Vector3 target;


    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        player = GameObject.Find("Player").transform;

    }

    private void Start()
    {
        Init();
    }


    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        Movement();

    }

    public virtual void Movement()
    {
        if (target == pointA.position)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            target = pointB.position;
            animator.SetTrigger("Idle");

        }
        else
        if (transform.position == pointB.position)
        {
            target = pointA.position;
            animator.SetTrigger("Idle");

        }

        if(isHit == false)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //check for player distance to enemy
        //if greater than 2 is hit = false;
        //in combat = false

       

        if(Vector3.Distance(player.position, transform.position) > 2.0f )
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }    

    }


}
