using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graczz : MonoBehaviour {
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a")){
			transform.Translate (Vector2.left * 2 * Time.deltaTime);
		}

		if(Input.GetKey("d")){
			transform.Translate (Vector2.right * 2 * Time.deltaTime);
		}

		if(Input.GetKey("w")){
			rb.AddForce(new Vector2(0, 100));
		}
	}
}
