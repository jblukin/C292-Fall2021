using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	//movement variables 
	[SerializeField] public float maxSpeed;


	//jumping variables
	bool grounded;

	[SerializeField] float groundCheckRadius;

	public LayerMask groundLayer;

	public Transform groundCheck;

	[SerializeField] public float jumpHeight;

	Rigidbody2D myRB;

	//Animator Anime;

	bool facingRight;

	// Start is called before the first frame update
	void Start()
	{
		myRB = GetComponent<Rigidbody2D>();
		//Anime = GetComponent<Animator>();
		facingRight = true;
		
	}

	// Update is called once per frame
	void Update()
	{

         if(grounded && Input.GetAxis("Jump") > 0) {


           Debug.Log("run");

            grounded = false;

             //MyAnim.SetBool ("isGrounded", grounded);

            myRB.AddForce(new Vector3(0, jumpHeight * maxSpeed, 0));
              
            //myRB.velocity = new Vector3(myRB.velocity.x, jumpHeight * maxSpeed, 0);


          } else if(!grounded) {

            //myRB.velocity = new Vector3(myRB.velocity.x, -1f * maxSpeed, 0);

          }

		// if(Input.GetAxis("Horizontal") > 0) {

		//     GetComponent<CharacterController>().Move(new Vector3(1, 0, 0) * Time.deltaTime);

		// } else if(Input.GetAxis("Horizontal") < 0) {

		//     GetComponent<CharacterController>().Move(new Vector3(-1, 0, 0) * Time.deltaTime);

		// }

	}

	 void FixedUpdate() {
		 
		  //check if we are grounded - if no, then we are falling

		  //grounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

		  Debug.Log(grounded);

		  //myAnim.SetBool ("isGrounded", grounded);

		  //myAnim.SetFloat("VerticalSpeed", myRB.velocity.y);

		  float move = Input.GetAxis("Horizontal");

		  //myAnim.SetFloat("Speed", Mathf.Abs(move));

		  myRB.velocity = new Vector3(move * maxSpeed, myRB.velocity.y, 0) * Time.deltaTime;

		  if (move > 0 && !facingRight) {

		      flip();

		  } else if (move < 0 && facingRight) {

		      flip();

		  }

	  }

	  void flip()
	  {
	      facingRight = !facingRight;

	      Vector3 theScale = transform.localScale;

	      theScale.x *= -1;

	      transform.localScale = theScale;
	  }

        void OnCollisionEnter(Collision other)
        {

        Debug.Log("collision");

        if (other.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }

        }
}

