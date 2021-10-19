using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	

	[SerializeField] float _maxSpeed;

	[SerializeField] float _jumpHeight;

	Rigidbody2D _myRB;

	bool _facingRight;

	[SerializeField] public bool isGrounded = true;


	void Start() {

		_facingRight = true;
        _myRB = GetComponent<Rigidbody2D>();

	}


	void Update() {

		if(transform.position.y < -5f) {

			transform.position = new Vector3(0, -3.9f, 0);

			_myRB.velocity = new Vector3(0, 0, 0);

		}

	}

	void flip() {

	      _facingRight = !_facingRight;

	      Vector3 theScale = transform.localScale;

	      theScale.x *= -1;

	      transform.localScale = theScale;

	  }

	void FixedUpdate() {

		if(Input.GetAxis("Vertical") > 0 && isGrounded) {

		Debug.Log("run");

		float vert = Input.GetAxis("Vertical");

		_myRB.AddForce(new Vector3(_myRB.velocity.x, _jumpHeight, 0) * Time.deltaTime, ForceMode2D.Impulse);
		//_myRB.velocity = new Vector3(_myRB.velocity.x, vert * _jumpHeight, 0) * Time.deltaTime;

		}

		float move = Input.GetAxis("Horizontal");
		
		Vector3 horizontalForce = new Vector3(move * _maxSpeed, _myRB.velocity.y, 0) * Time.deltaTime;

		if(Mathf.Abs(_myRB.velocity.x) < _maxSpeed) {

		_myRB.AddForce(horizontalForce, ForceMode2D.Impulse);

		} else {

			float maxSpeedLocal = _maxSpeed;

			if(_myRB.velocity.x < 0) {

				maxSpeedLocal = -maxSpeedLocal;

			}

			_myRB.velocity = new Vector3(maxSpeedLocal, _myRB.velocity.y, 0);

		}

			if (move > 0 && !_facingRight) {

				flip();

			} else if (move < 0 && _facingRight) {

				flip();

			}

		}


}