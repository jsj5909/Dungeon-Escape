using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private bool _grounded = true;

    [SerializeField] private float _speed = 2;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private LayerMask _groundLayer;


    private bool _resetJumpNeeded = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _groundLayer= LayerMask.GetMask("Ground");

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigidBody.velocity = new Vector2(move, _jumpForce);
            _grounded = false;
            _resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());

        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down,0.8f,_groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hitInfo.collider != null)
        {
            if (_resetJumpNeeded == false)
            {
                _grounded = true;
            }
        }
      
        _rigidBody.velocity = new Vector2(move, _rigidBody.velocity.y);
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }


}
