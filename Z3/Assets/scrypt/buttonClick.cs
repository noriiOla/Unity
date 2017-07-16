using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonClick : MonoBehaviour {
	//public Button buttonYes;
	///public Button buttonNo;
	// Use this for initialization
	void Start () {
	//	buttonYes.onClick.AddListener (delegate() {
	//		Debug.Log("YES!");
	//		this.GetComponent<gameManager> ().restartGame ();
	//	});
	//	buttonNo.onClick.AddListener (delegate() {
	//		Debug.Log("NO!");
	//		Application.Quit ();
	//	});
		//buttonYes.GetComponent<Button> ().onClick.AddListener (restartThisGame);
		//buttonNo.GetComponent<Button> ().onClick.AddListener (quit);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void restartThisGame(){
		Debug.Log ("DAWD");
		this.GetComponent<gameManager> ().restartGame ();
	}

	public void quit(){
		Application.Quit ();
	}
}
