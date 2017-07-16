using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireGet : MonoBehaviour {
	public GameObject manager;
	int score;

	void Start () {
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.CompareTag("fireWall")){
			Destroy (coll.gameObject);
			manager.GetComponent<gameManager> ().plusScore ();
		}
	}
}
