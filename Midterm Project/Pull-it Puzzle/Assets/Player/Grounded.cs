using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject Player;

    void Start() {

        Player = gameObject.transform.parent.gameObject;

    }

    void OnCollisionEnter2D(Collision2D collision) {

		 if(collision.collider.tag == "Ground") {

			 Player.GetComponent<PlayerMovement>().isGrounded = true;

		 }

         Debug.Log(Player.GetComponent<PlayerMovement>().isGrounded);

	 }

	 void OnCollisionExit2D(Collision2D collision) {

		 if(collision.collider.tag == "Ground") {

			 Player.GetComponent<PlayerMovement>().isGrounded = false;

		 }

         Debug.Log(Player.GetComponent<PlayerMovement>().isGrounded);


	 }
}
