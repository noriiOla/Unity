using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullBox : MonoBehaviour {

	public float distance = 50;
	public float speed = 1;
	public GameObject ball;
	public float power = 2000; 
	private bool ready = false;
	private bool fire = false;
	private float moveCount = 0;

	private float startedPosX;
	private float startedPosY;
	private float startedPosZ;
	// Use this for initialization
	void Start () {
		
		startedPosX = this.gameObject.transform.position.x;
		startedPosY = this.gameObject.transform.position.y;
		startedPosZ = this.gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			//As the button is held down, slowly move the piece
			if (moveCount < distance) {
				transform.Translate (0, 0, -speed * Time.deltaTime);
				moveCount += speed * Time.deltaTime;
				fire = true;
			}
		} else {
			
			if (startedPosZ + 0.3 > this.gameObject.transform.position.z) {
				transform.Translate(0,0,1 * Time.deltaTime);
				moveCount -= 1 * Time.deltaTime;
			}
		
			if(fire && ready){
				fire = false;
				ready = false;
				ball.transform.TransformDirection(Vector3.forward * 10);
				ball.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			ready = false;
			fire = false;
		}

	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ball") {
			ready = true;
		}
	}

}
