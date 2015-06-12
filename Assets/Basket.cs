﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText		scoreGT;

	// Use this for initialization
	void Start () {
		GameObject scoreGo = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGo.GetComponent<GUIText> ();
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 mousePos2d = Input.mousePosition;

		mousePos2d.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2d);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

	}

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if(collidedWith.tag == "Apple"){
			Destroy (collidedWith);
		}

		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString ();

		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}

}