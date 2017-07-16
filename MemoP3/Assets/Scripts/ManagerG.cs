using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerG : MonoBehaviour {
	
	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text score;
	public Button repeatButtonStart;
	public LayerMask layerMask;
	public static bool allowClick = false;
	public Text buttonText;

	// Use this for initialization
	void Start () {
		allowClick = true;
		repeatButtonStart.onClick.AddListener (delegate() {
			for (int numberOfCard = 0; numberOfCard < cards.Length; numberOfCard++) {
				cards [numberOfCard].GetComponent<SimpleCard> ().initializedC = false;
				cards [numberOfCard].GetComponent<SimpleCard> ().stateC = 0;
				buttonText.text = "Replay";
				score.text = "0";
			}
			shuffleCards ();
			allowClick = true;
		});
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void checkCard(){
		List<int> c = new List<int> ();

		for (int i = 0; i < cards.Length; i++) {
			if (cards [i].GetComponent<SimpleCard> ().stateC == 1) {
				c.Add (i);
			}
		}

		if (c.Count == 2) {
			compare (c);
		} 
	}

	public void shuffleCards(){

		for (int repearNumber = 0; repearNumber < 2; repearNumber++) {
			for (int imageNumber = 0; imageNumber < cardFace.Length; imageNumber++) {
				bool finded = false;
				int choice = 0;
				while (!finded) {
					choice = Random.Range (0, cards.Length);
					finded = !(cards [choice].GetComponent<SimpleCard> ().initializedC);
				}
				cards [choice].GetComponent<SimpleCard> ().cardValueC = imageNumber;
				cards [choice].GetComponent<SimpleCard> ().initializedC = true;
			}
		}

		foreach (GameObject card in cards) {
			card.GetComponent<SimpleCard> ().setupGraphics ();
		}

	}

	public Sprite getCardBack(){
		return cardBack;
	}

	public Sprite getCartFace(int i) {
		return cardFace[i];
	}

	void compare(List<int> listOfStatedCard){
		if( buttonText.text == "Replay"){
			int x = 0;
			if (cards [listOfStatedCard [0]].GetComponent<SimpleCard> ().cardValueC == cards [listOfStatedCard [1]].GetComponent<SimpleCard> ().cardValueC) {
				cards [listOfStatedCard [0]].GetComponent<SimpleCard> ().stateC = 2;
				cards [listOfStatedCard [1]].GetComponent<SimpleCard> ().stateC = 2;

				score.text = (int.Parse(score.text) + 2).ToString();
			} else {
				for (int i = 0; i < listOfStatedCard.Count; i++) {
					cards [listOfStatedCard [i]].GetComponent<SimpleCard> ().stateC = x;
					cards [listOfStatedCard [i]].GetComponent<SimpleCard> ().falseCheck ();
				}
				score.text = (int.Parse(score.text) - 1).ToString();
			}
		}
	}
}
