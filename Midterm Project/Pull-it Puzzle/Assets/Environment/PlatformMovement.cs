using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float _moveSpeed = 0.075f;

    public bool _canMove = true;

    public Transform _movePoint;


    public LayerMask whatStopsMovement;



    void Start()
    {
        _movePoint = GetComponent<Transform>();
        _movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        MagicGrab();

        if (!_canMove)
        {

            transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _movePoint.position) <= 0.05f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("BHorz")) == 1f)
                {

                    if (!Physics2D.OverlapCircle(_movePoint.position + new Vector3(Input.GetAxisRaw("BHorz"), 0f, 0f), 0.5f, whatStopsMovement))
                    {

                        _movePoint.position += new Vector3(Input.GetAxisRaw("BHorz"), 0f, 0f) * _moveSpeed;

                        print(_movePoint.position.x);

                    }

                }
                else if (Mathf.Abs(Input.GetAxisRaw("BVert")) == 1f)
                {

                    if (!Physics2D.OverlapCircle(_movePoint.position + new Vector3(0f, Input.GetAxisRaw("BVert"), 0f), 0.5f, whatStopsMovement))
                    {

                        _movePoint.position += new Vector3(0f, Input.GetAxisRaw("BVert"), 0f) * _moveSpeed;

                        print(_movePoint.position.y);

                    }

                }

            }

        }
    }

    void MagicGrab()
    {

        if (Input.GetButtonDown("Grab"))
        {

            _canMove = !_canMove;


        }

    }
}
