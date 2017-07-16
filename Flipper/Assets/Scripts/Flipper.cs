using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

	public float pressedPosition  = 45F;
	public float flipperStrength  = 10F;
	public float flipperDamper  = 0F;
	public string inputButtonName = "LeftPaddle";
	JointSpring hingeSpring;
	HingeJoint[] hinges;
	public GameObject ball;
	private bool ok = false;
	// Use this for initialization
	void Start () {
		hinges = this.GetComponents<HingeJoint> ();
		foreach (HingeJoint joint in hinges) {
			JointLimits limits = joint.limits;
			limits.min = 0;
			if(inputButtonName.Equals("LFlipper")){
				limits.max = pressedPosition;
			}
			if(	inputButtonName.Equals("RFlipper")){
				limits.max = pressedPosition*-1;
			}
			joint.limits = limits;
			joint.useSpring = true;
			joint.useLimits = true;
		}
		hingeSpring.spring = flipperStrength;
		hingeSpring.damper = flipperDamper;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKey (KeyCode.RightArrow) && inputButtonName.Equals("RFlipper")) {
			this.gameObject.transform.TransformDirection(Vector3.forward * 10);
			this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 1000);
			ok = true;
			//this.gameObject.transform.Translate (Vector3.forward * 20 * Time.deltaTime);
			//this.gameObject.transform.RotateAround(hinges[0].axis, Vector3.forward , 30 *Time.deltaTime);
			//hinges [0].axis = new Vector3(0,1,0);
			//hingeSpring.targetPosition = pressedPosition;
		}
		if (Input.GetKey (KeyCode.LeftArrow) && inputButtonName.Equals("LFlipper")) {
			ok = true;
			this.gameObject.transform.TransformDirection(Vector3.forward * 10);
			this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 1000);
			//this.gameObject.transform.Translate (Vector3.forward * 20 * Time.deltaTime);
			//this.gameObject.transform.RotateAround(hinges[0].axis, Vector3.forward, 30 *Time.deltaTime);

			//hinges [0].axis = new Vector3(0,1,0);
			//hingeSpring.targetPosition = pressedPosition * -1;
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) && inputButtonName.Equals("RFlipper")) {
			ok = false;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && inputButtonName.Equals("LFlipper")) {
			ok = false;
		}

		hinges[0].spring = hingeSpring;
		hingeSpring = hinges[0].spring;
	}

	IEnumerator pause(){
		yield return new WaitForSeconds(1);
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Ball" && ok == true) {
			ball.transform.TransformDirection(Vector3.forward * 10);
			ball.GetComponent<Rigidbody>().AddForce(1, 1, 10 * 50);

		}
	}


}
