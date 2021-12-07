using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    bool _grabbed;

    RaycastHit2D hit;

    Collider2D _collider = null;

    public float _jumpForce = 20f;

    public Transform _feet;

    public LayerMask _groundLayers;

    public AudioSource _grabSound;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _canMove = true;
        _spawnPoint = new Vector3(-18f, -0.8f, 0f);
        _grabSound = GetComponentInChildren<AudioSource>();

    }


    void Update()
    {

        MagicGrab();

        if (transform.position.y <= -10f)
        {

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

                Flip();

            }
            else if (_rb.velocity.x > 0 && _facingRight)
            {

                Flip();

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

    void Flip()
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

            if (_grabbed)
            {

                _grabbed = false;

                _collider.SendMessage("MagicGrab", 0, SendMessageOptions.DontRequireReceiver);

                _collider = null;

            }

        }

        if (!_canMove)
        {

            if (Input.GetAxisRaw("Vertical") == 1f)
            {

                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up));
                sendMessage(1);

            }
            else if (Input.GetAxisRaw("Horizontal") == 1f)
            {

                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right));
                sendMessage(2);
                if(_facingRight) {

                    Flip();

                }

            }
            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {

                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left));
                sendMessage(2);
                if(!_facingRight) {

                    Flip();

                }

            }

        }

    }

    void sendMessage(int direction)
    {

        if (hit.collider.tag == "Moveable")
        {
            _collider = hit.collider;
        }

        if (!_grabbed)
        {

            _collider.SendMessage("MagicGrab", direction, SendMessageOptions.DontRequireReceiver);
            _grabbed = true;
            _grabSound.Play();

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Scene current = SceneManager.GetActiveScene();

        if (collision.collider.tag == "Goal")
        {
            if (current.name == "Level1")
            {

                SceneManager.LoadScene("Level2");

            }
            else if (current.name == "Level2")
            {

                SceneManager.LoadScene("EndScreen");
            }

        }

    }

}