using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim; 
	public AudioSource audioSource;
	private bool isJumping;
	float maxSpeed = 5f;
	bool isStartGame;
	public float volume = 0.5f;
	public float minVolume = 0.0f;
	public float maxVolume = 1.0f;
	public GameObject fireAball;
	private bool isAtackingNow = false;
	public float fireForce;
	public float transformRotation; 
	void Start ()
	{
		transformRotation = 90f;
		isStartGame = true;
		anim = this.GetComponent<Animator> ();
		isJumping = true;
		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
		audioSource = this.GetComponent<AudioSource> ();
	}
		
	void FixedUpdate() {
		var horizontal = Input.GetAxis ("Horizontal");

		if (horizontal > 0) {
			anim.SetInteger ("direction", 2);
			transformRotation = 90f;
		} else {
			if (horizontal < 0) {
				anim.SetInteger ("direction", 1);
				transformRotation = 270f;
			} else {
				anim.SetInteger ("direction", 0);
			}
		}

		rb.velocity = new Vector2 (maxSpeed * horizontal, rb.velocity.y);
	}

	void Update () {
		/*
		if(Input.GetKey("a")){
			transform.Translate (Vector2.left * 2 * Time.deltaTime);
		}

		if(Input.GetKey("d")){
			transform.Translate (Vector2.right * 2 * Time.deltaTime);
		}
		*/
		if(Input.GetKey("w")){
			if (isJumping == false ) {
				isJumping = true;
				playJumpAudio ();
				rb.AddForce (new Vector2 (0, 300));
			}
		}

		audioSource.volume = volume;

		if (Input.GetKeyDown ("p") && (!isAtackingNow)) {
			isAtackingNow = true;
			GameObject fireAtackBall = Instantiate (fireAball, transform.position, Quaternion.Euler (0f, 0f, transformRotation));
			fireAtackBall.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2(0f, -fireForce));
			fireAtackBall.AddComponent<fireAtackBall> ();
		}

		if (Input.GetKeyUp ("p") && (isAtackingNow)) {
			isAtackingNow = false;
		}

	}

	void OnGUI(){
		GUI.Label (new Rect (150, 0, 100, 30), "Volume");
		volume = GUI.HorizontalSlider (new Rect (150, 30, 100, 30), volume, minVolume, maxVolume);
	}

	void playJumpAudio(){
		audioSource.PlayOneShot (audioSource.clip);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Ground") {
			isJumping = false;
		}
	}

	public void setToStart(){
		this.transform.position = new Vector3 (-0.88f, -1.5f, 0);
	}
}
