using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCollisionScrip : MonoBehaviour {
	public GameObject manager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("Potwor");
			if (this.transform.position.x <= coll.transform.position.x) {
				this.transform.position = this.transform.position + new Vector3 (-3, 0);
				if (this.transform.position.x < -7.5f) {
					this.transform.position = this.transform.position + new Vector3 (6, 0);
				}
			} else {
				this.transform.position = this.transform.position + new Vector3 (3, 0);
				if (this.transform.position.x > 6.5f) {
					this.transform.position = this.transform.position - new Vector3 (6, 0);
				}
			}
			manager.GetComponent<gameManager> ().minusLive ();
		}else{
			if(coll.gameObject.CompareTag ("Ground")) {
				Debug.Log ("Ziemia");
			//	manager.GetComponent<gameManager> ().setCurrentGround (coll.transform.position.y);
			}
		}
	}
}

