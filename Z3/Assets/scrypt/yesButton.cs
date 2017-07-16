using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class yesButton : MonoBehaviour {
	public Button b; 
	// Use this for initialization
	void Start () {
		b.onClick.AddListener (delegate() {
			Debug.Log("YES!");
			this.GetComponent<gameManager> ().restartGame ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
