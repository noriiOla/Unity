using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
	public Text livesText;
	public Text scoreText;
	public GameObject gracz;
	public GameObject enemyob;
	public Text panelText;
	public GameObject panel;
	public float currentGroundY;
	int live = 3;
	int score = 0;
	float[] platformHeights;

	// Use this for initialization
	void Start () {
		live = 3;
		score = 0;
		currentGroundY = gracz.transform.position.y;
		initPlatformHeights ();		
		panel.SetActive (false);
	}

	public void initPlatformHeights(){

		var gameObjects = GameObject.FindGameObjectsWithTag ("Ground");
		platformHeights = new float[gameObjects.Length];
		int i = 0;
		foreach (GameObject obj in gameObjects) {
			platformHeights [i] = obj.transform.position.y;
			i++;
		}
		foreach (float y in platformHeights) {
			Debug.Log (y);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setCurrentGround(float y){
		if ((y + 4) < currentGroundY) {
			restartGameWithoutLiveMinus ();
		} else {
			currentGroundY = y;
		}
	}

	public void restartGameWithoutLiveMinus(){
		this.GetComponent<FireSprayer> ().Spawn ();
		gracz.GetComponent<Gracz> ().setToStart ();
		enemyob.GetComponent<enemy> ().resetAnimation ();
	}

	public void initAll(){
		score = 0;
		live = 3;
		scoreText.text = "Score " + score.ToString ();
		livesText.text = "Lives " + live.ToString ();
		restartGameWithoutLiveMinus ();
	}

	public void minusLive(){
		live = live - 1;
		livesText.text = "Lives " + live.ToString ();
		if (live == 0) {
			enemyob.GetComponent<enemy> ().stopAnimation ();
			panel.SetActive(true);
			panelText.text = "you lose, restart game?";
			//restartGame ();
		}
	}

	public void restartGame(){
		panel.SetActive (false);
		//komunikat czy chesz zagrac raz jeszcze?
		Application.LoadLevel("something");
	}

	public void plusScore(){
		score = score + 1;

		scoreText.text = "Score " + score.ToString ();
		if(score == 10){
			Scene s = SceneManager.GetActiveScene ();
			if (s.name == "1r2") {
				panel.SetActive (true);
				panelText.text = "You win, restart game?";
			} else {
				Application.LoadLevel ("1r2");
			}
		}
	}

	public void startFromBeginning(){
		
	}

}
