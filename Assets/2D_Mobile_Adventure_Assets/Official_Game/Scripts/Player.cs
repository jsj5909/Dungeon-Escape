using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody;


    private SpriteRenderer _playerSprite;

    private bool _grounded = true;

    [SerializeField] private float _speed = 2;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private LayerMask _groundLayer;

    private PlayerAnimation _playerAnimation;

    private bool _resetJumpNeeded = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _groundLayer= LayerMask.GetMask("Ground");

        _playerAnimation = GetComponent<PlayerAnimation>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Movement();

        
      
        
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
        }

        _playerAnimation.Move(move);

    }

    void Flip(float move)
    {
        if (move > 0)
        {
            _playerSprite.flipX = false;
        }
        else
       if (move < 0)
        {
            _playerSprite.flipX = true;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);

        if (hitInfo.collider != null)
        {
            if(_resetJumpNeeded == false)
                return true;
            
        }

        return false;
       
    }

   

    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
   }


}
