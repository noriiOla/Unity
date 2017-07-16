using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class przeszkodySkrypt : MonoBehaviour {
	
	public AudioSource audioSource;
	public float duration = 0.0F;
	public Color colorStart = Color.red;
	public Color colorEnd = Color.blue;
	public Renderer rend;
	public GameObject ball;

	void Start () {
		audioSource = this.GetComponent<AudioSource> ();
		rend = GetComponent<Renderer>();
	}
	
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ball") {
			//ball.transform.TransformDirection(Vector3.forward * 10);
			ball.GetComponent<Rigidbody>().AddForce(0, 0, 10 * 50);
			audioSource.PlayOneShot (audioSource.clip);
			var color = rend.material.color;
			this.rend.material.color = Color.red;

			StartCoroutine(pause(color));
		}
	}

	IEnumerator pause(Color color){
		yield return new WaitForSeconds(1);
		this.rend.material.color = color;
	}
}
