﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject GameOverText;
	public Text ScoreText;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	private int score = 0;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		
	}

	public void HeroScored(){

		if (gameOver == true) {
			return;
		}

		score++;
		ScoreText.text = "Score: " + score.ToString ();
	}

	public void HeroDied(){
		GameOverText.SetActive(true);
		gameOver = true;

	}
}
