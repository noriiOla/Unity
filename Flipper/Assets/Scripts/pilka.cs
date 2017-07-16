using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pilka : MonoBehaviour {
	public TextMesh scoreText;
	private int score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "przeszk1") {
			this.score = score + 1;
			scoreText.text = "Score: " + score;
		} else {
			if (coll.gameObject.tag == "przeszk2") {
				this.score = score + 2;
				scoreText.text = "Score: " + score;
			}
		}
	}
}
