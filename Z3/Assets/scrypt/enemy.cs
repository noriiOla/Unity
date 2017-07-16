using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	Rigidbody2D rb;
	private bool isJumping;

	void Start ()
	{
		isJumping = false;
		rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetAnimation(){
		this.GetComponent<Animator> ().Rebind ();
	}

	public void stopAnimation(){
		this.GetComponent<Animator> ().Stop ();
	}
}
