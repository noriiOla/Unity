using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAtackBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("DAWDA");
			Destroy (coll.gameObject);
			Destroy (this.gameObject);
		}
	}
}
