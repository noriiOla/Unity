using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleCard : MonoBehaviour {
	
	public Sprite cardBack;
	public Sprite cardFrond;
	public GameObject manager;

	private int cardValue;
	private int state;
	private bool initialized = false;

	// Use this for initialization
	void Start () {
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setupGraphics(){
		cardBack = manager.GetComponent<ManagerG> ().getCardBack ();
		cardFrond = manager.GetComponent<ManagerG> ().getCartFace (cardValue);

		flipCard ();
	}

	public void changeState(){
		if (state == 0) {
			state = 1;
		} 
		flipCard ();
		manager.GetComponent<ManagerG> ().checkCard();
	}

	public void flipCard(){
		if (state == 0 ) {
			GetComponent<Image> ().sprite = cardBack;
		} else {
			if (state == 1) {
				GetComponent<Image> ().sprite = cardFrond;
			}
		}
		ManagerG.allowClick = true;
	}

	public int cardValueC{
		get { return cardValue;}
		set { cardValue = value;}
	}

	public int stateC{
		get { return state;}
		set { state = value;}
	}

	public bool initializedC{
		get { return initialized;}
		set { initialized = value;}
	}
		
	public void falseCheck() {
		StartCoroutine (pause ());
	}

	IEnumerator pause() {
		yield return new WaitForSeconds(1);
		if(state == 0){
			GetComponent<Image> ().sprite = cardBack;
		}
	}
}
