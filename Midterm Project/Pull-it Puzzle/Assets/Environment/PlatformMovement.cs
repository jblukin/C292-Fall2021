using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float _moveSpeed = 0.075f;

    public bool grabbed = false;

    public Transform _movePoint;

    public LayerMask whatStopsMovement;
    
    int _direction = 0;

    Collider2D _collider;


    void Start()
    {
        _movePoint = GetComponent<Transform>();
        _movePoint.parent = null;
        _collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (grabbed)
        {

            transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _movePoint.position) <= 0.05f)
            {

                if (_direction == 1)
                {
                    if (Input.GetAxisRaw("BVert") == 1f)
                    {

                        if (!Physics2D.OverlapBox(_movePoint.position + new Vector3(0f, Input.GetAxisRaw("BVert") - 0.85f, 0f), _collider.bounds.size, 0f, whatStopsMovement))
                        {

                            _movePoint.position += new Vector3(0f, Input.GetAxisRaw("BVert"), 0f) * _moveSpeed;

                            print(_movePoint.position.y);

                        }

                    }
                    else if (Input.GetAxisRaw("BVert") == -1f)
                    {

                        if (!Physics2D.OverlapBox(_movePoint.position + new Vector3(0f, Input.GetAxisRaw("BVert") + 0.85f, 0f), _collider.bounds.size, 0f, whatStopsMovement))
                        {

                            _movePoint.position += new Vector3(0f, Input.GetAxisRaw("BVert"), 0f) * _moveSpeed;

                            print(_movePoint.position.y);

                        }

                    }

                }
                else if (_direction == 2)
                {
                    if (Input.GetAxisRaw("BHorz") == 1f)
                    {

                        if (!Physics2D.OverlapBox(_movePoint.position + new Vector3(Input.GetAxisRaw("BHorz") - 0.85f, 0f, 0f), _collider.bounds.size, 0f, whatStopsMovement))
                        {

                            _movePoint.position += new Vector3(Input.GetAxisRaw("BHorz"), 0f, 0f) * _moveSpeed;

                            print(_movePoint.position.x);

                        }

                    }
                    else if (Input.GetAxisRaw("BHorz") == -1f)
                    {

                        if (!Physics2D.OverlapBox(_movePoint.position + new Vector3(Input.GetAxisRaw("BHorz") + 0.85f, 0f, 0f), _collider.bounds.size, 0f, whatStopsMovement))
                        {

                            _movePoint.position += new Vector3(Input.GetAxisRaw("BHorz"), 0f, 0f) * _moveSpeed;

                            print(_movePoint.position.x);

                        }

                    }


                }


            }

        }
    }

    void MagicGrab(int direction)
    {

        grabbed = !grabbed;
        _direction = direction;

    }

}
