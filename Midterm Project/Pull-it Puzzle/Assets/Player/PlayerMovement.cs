using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float _moveSpeed;

	public Vector3 _spawnPoint;

    public Rigidbody2D _rb;

    public Animator anime;

    float mx;
    bool _facingRight;

    bool _isGrounded;

    bool _canMove;

    public float _jumpForce = 20f;

    public Transform _feet;

    public LayerMask _groundLayers;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _canMove = true;
		_spawnPoint = new Vector3(-12f, -3.9f, 0f);
    }


    void Update()
    {

        MagicGrab();

		if(transform.position.y <= -10f) {

			transform.position = _spawnPoint;

		}

        if (_canMove)
        {

            mx = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {

                Jump();

            }

            if (Mathf.Abs(mx) > 0.05)
            {

                anime.SetBool("isRunning", true);

            }
            else
            {

                anime.SetBool("isRunning", false);

            }

            anime.SetBool("isGrounded", IsGrounded());

        }

    }

    void FixedUpdate()
    {

        if (_canMove)
        {

            Vector3 movement = new Vector3(mx * _moveSpeed, _rb.velocity.y, 0);

            _rb.velocity = movement;

            if (_rb.velocity.x < 0 && !_facingRight)
            {

                flip();

            }
            else if (_rb.velocity.x > 0 && _facingRight)
            {

                flip();

            }

        }
    }

    public bool IsGrounded()
    {

        Collider2D groundCheck = Physics2D.OverlapCircle(_feet.position, 0.5f, _groundLayers);

        if (groundCheck != null)
        {

            return true;

        }
        else return false;

    }

    void flip()
    {

        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

    }

    void Jump()
    {

        Vector3 movement = new Vector3(_rb.velocity.x, _jumpForce, 0f);

        _rb.velocity = movement;

    }

    void MagicGrab()
    {

        if (Input.GetButtonDown("Grab") && IsGrounded())
        {

            _canMove = !_canMove;

			anime.SetBool("isGrabbing", !_canMove);

			anime.SetBool("isRunning", false);

			_rb.velocity = new Vector3(0f, 0f, 0f);

        }

    }

}