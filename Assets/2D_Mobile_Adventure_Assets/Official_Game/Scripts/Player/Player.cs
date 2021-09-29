using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody2D _rigidBody;


    private SpriteRenderer _playerSprite;
    private SpriteRenderer _arcSprite;

    private bool _grounded = true;

    [SerializeField] private float _speed = 2;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private LayerMask _groundLayer;

    private PlayerAnimation _playerAnimation;

    

    private bool _resetJumpNeeded = false;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _groundLayer= LayerMask.GetMask("Ground");

        _playerAnimation = GetComponent<PlayerAnimation>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        _arcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Movement();

        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
      
        
    }

    

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        Flip(move);

        _rigidBody.velocity = new Vector2(move *_speed, _rigidBody.velocity.y );

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());

            _playerAnimation.Jump(true);
        }

        if(IsGrounded())
        {
            _playerAnimation.Jump(false) ;
        }

        _playerAnimation.Move(move);

    }

    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
            _arcSprite.flipX = false;
            _arcSprite.flipY = false;

            Vector3 newPos = _arcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _arcSprite.transform.localPosition = newPos;
        }
        else
       if (move < 0)
        {
            _playerSprite.flipX = true;
            _arcSprite.flipX = true;
            _arcSprite.flipY = true;

            Vector3 newPos = _arcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _arcSprite.transform.localPosition = newPos;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);

        if (hitInfo.collider != null)
        {
           
            
            if (_resetJumpNeeded == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
            
        }

        return false;
       
    }

   

    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
   }

    public void Damage()
    {
        Debug.Log("Player Damaged");
    }
}
