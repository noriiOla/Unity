using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprayer : MonoBehaviour {
	public int num = 3;
	public GameObject fireWall;
	public float offSetRange = 1.5f;
	// Use this for initialization
	void Start () {
		fireWall.transform.localScale = new Vector3 (0.2f, 0.2f, 1);
		Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn(){
		deleteFireWalls ();
		for (int i = 0; i < num; i++) {
			Vector2 spawnOffSet = new Vector2(Random.Range (-6.0f, 6.0f ), Random.Range (1.5f, 6.5f ));
			Instantiate(fireWall, (Vector2)transform.position + spawnOffSet, Quaternion.identity);
		}
	}

	public void deleteFireWalls(){
		var gameObjects = GameObject.FindGameObjectsWithTag ("fireWall");
		foreach (GameObject gameObj in gameObjects) {
			Destroy (gameObj);
		}
	}
}
