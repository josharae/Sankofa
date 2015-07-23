﻿using UnityEngine;
using System.Collections;

public class GlobalVariablesScript : MonoBehaviour {
	bool defeatedGiwa = false,eggIsBroken = false;
	public GameObject loadingScreen;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find (fsdjkfl.GlobalObject).GetComponent<GlobalVariablesScript> ().giwaDefeated ();
	}

	public void loadingNewSCene(){
		loadingScreen.SetActive (true);
	}

	void OnLevelWasLoaded (){
		Invoke ("disableLoad", 0.3f);
	}

	void disableLoad(){
		loadingScreen.SetActive (false);
	}

	public void giwaDefeated(){
		if(!defeatedGiwa){
			defeatedGiwa = true;
			Scenes.LoadGame();
		}
	}

	public void brokenEgg(){
		if(!eggIsBroken){
			eggIsBroken = true;
			Scenes.LoadGame();
		}
	}
}
