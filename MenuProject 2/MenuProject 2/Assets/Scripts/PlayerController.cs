using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/* 
 * Source file name: Youtube Video (COMP305 - W2016 - )
Author's name: Fatimah 
Last Modified by: Ramandip Singh
Date last Modified: April15th, 2016
Program Description: Simple 2d game platformer where you can collect coins when you go over the platForm
*/

//VelocityRange class 
[System.Serializable]
public class VelocityRange{
	//public variables
	public float minimum; 
	public float maximum;

	//constructor
	public VelocityRange(float minimum, float maximum){
		minimum = 300f;
		maximum = 1000f;
	}
}

public class PlayerController : MonoBehaviour {

	//public variables
	public VelocityRange velocityRange;
	public float moveForce; 
	public float jumpForce; 
	public Transform groundCheck;
	public Transform camera; 
	public GameController gameController;

	//private variables 
	private Animator animator;
	private float move; 
	private float jump; 
	private bool facingRight; 
	private Transform transform;
	private Rigidbody2D rigidBody2d;
	private bool isGrounded;
	private AudioSource[] audioSources;
	private AudioSource coinSound;
	private AudioSource hurtSound;
	private AudioSource jumpSound; 


	// Use this for initialization
	void Start () {
		
		//initialize public variables
		velocityRange = new VelocityRange(1000f, 55000f);

		//initialize private variables
		transform = gameObject.GetComponent<Transform> ();
		animator = gameObject.GetComponent<Animator> ();
		rigidBody2d = gameObject.GetComponent<Rigidbody2D> ();
		move = 0f; 
		jump = 0f; 
		facingRight = true; 

		//Audio Sources
		audioSources = gameObject.GetComponents<AudioSource>();
		coinSound = audioSources [0];
		hurtSound = audioSources [1];
		jumpSound = audioSources [2];

		//player in start position
		spawn();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 currentPosition = new Vector3 (transform.position.x, transform.position.y, -10f);
		camera.position = currentPosition;

		isGrounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		Debug.DrawLine (transform.position, groundCheck.position);


		float forceX = 0f;
		float forceY = 0f; 

		//absolute value for velocity for gameObject
		float absVelX = Mathf.Abs (rigidBody2d.velocity.x);
		float absVelY = Mathf.Abs (rigidBody2d.velocity.y);

		//check if player grounded before move 
		if (isGrounded) {
			//number between -1 to 1
			move = Input.GetAxis ("Horizontal");
			jump = Input.GetAxis ("Vertical");

			if (move != 0) {
				if (move > 0) {
					//Force
					if(absVelX < velocityRange.maximum){
						forceX = moveForce;
					}
						
					facingRight = true;
					flip ();
				}
				if (move < 0) {
					//Force
					if(absVelX < velocityRange.maximum){
						forceX = -moveForce;
					}
					facingRight = false;
					flip ();
				}
				// walk animation
				animator.SetInteger ("Anim_State", 1);

			} else {
				//default animation state
				animator.SetInteger ("Anim_State", 0);

			}
			if (jump > 0) {
				//Force
				if(absVelY < velocityRange.maximum){
					jumpSound.Play ();
					forceY = jumpForce;
				}
			}	
		} else {
			// jump animatoiton
			animator.SetInteger ("Anim_State", 2);
		
		}
		//apply forces
		rigidBody2d.AddForce (new Vector2 (forceX, forceY));			
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Coin")) {
			coinSound.Play ();
			Destroy (other.gameObject);
			gameController.ScoreValue += 10;
		}
		if (other.gameObject.CompareTag ("Death")) {
			spawn ();
			hurtSound.Play ();
			gameController.LivesValue--;
		}
        if (other.gameObject.CompareTag("enemy"))
        {
            
            hurtSound.Play();
            gameController.LivesValue --;

        }
		if(other.gameObject.CompareTag("nextlvl"))
		{
			SceneManager.LoadScene ("Level2");
		}

    }
	//private methods
	private void flip(){
		if (facingRight) {
			transform.localScale = new Vector2 (1, 1);
		}else {
			transform.localScale = new Vector2 (-1, 1);

	}

}
	private void spawn(){
        transform.position = new Vector3(-12329f, -15714.42f, 0);
}
}